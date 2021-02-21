using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsumerProducerUsingChannels
{
    class Program
    {
        // Main settings for application
        private static readonly string _directory = @"C:\users\turek\desktop\";
        private static readonly string _fileName = "testFile.txt";
        private static readonly string _rewriteFileName = "testFileRewritten.txt";
        private static readonly string _path = Path.Combine(_directory, _fileName);
        private static readonly string _rewritePath = Path.Combine(_directory, _rewriteFileName);
        private static readonly int _linesCount = 10;
        // Only when delay is involved, advantage of Channel can be seen.
        // Reading single line of file is fast enough to work synchronously.
        private static readonly int _readerDelayMs = 50;
        private static readonly int _writerDelayMs = 50;

        static void Main(string[] args)
        {
            File.Delete(_path);
            File.Delete(_rewritePath);
            GenerateFile(_linesCount, "hello world", _path);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            RewriteFileWithStreamsOnly().Wait();
            stopwatch.Stop();
            Console.WriteLine($"{nameof(RewriteFileWithStreamsOnly)} took {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Reset();
            stopwatch.Start();
            RewriteFilesWithChannels();
            stopwatch.Stop();
            Console.WriteLine($"{nameof(RewriteFilesWithChannels)} took {stopwatch.ElapsedMilliseconds} ms");
        }

        private static async Task RewriteFileWithStreamsOnly()
        {
            Console.WriteLine($"Starting {nameof(RewriteFileWithStreamsOnly)}");

            using var reader = new StreamReader(_path);
            using var writer = new StreamWriter(_rewritePath);
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                await writer.WriteAsync(line);
                await Task.Delay(_readerDelayMs + _writerDelayMs);
            }

            Console.WriteLine($"Ended {nameof(RewriteFileWithStreamsOnly)}");
        }
        
        private static void RewriteFilesWithChannels()
        {
            Console.WriteLine($"Starting {nameof(RewriteFilesWithChannels)}");

            var options = new UnboundedChannelOptions();
            options.SingleReader = true;
            options.SingleWriter = true;
            var channel = Channel.CreateUnbounded<string>(options);
            // Here we run writer and reader tasks.
            var writerTask = ReadFromChannel(channel);
            var readerTask = WriteToChannel(channel);
            Task.WhenAll(writerTask, readerTask).Wait();

            Console.WriteLine($"Ended {nameof(RewriteFilesWithChannels)}");
        }

        private static async Task ReadFromChannel(Channel<string> channel)
        {
            var writer = new StreamWriter(_rewritePath);

            var completionTask = channel.Reader.Completion;
            try
            {
                while (await channel.Reader.WaitToReadAsync().ConfigureAwait(false))
                {
                    await Task.Delay(_readerDelayMs).ConfigureAwait(false);
                    channel.Reader.TryRead(out string line);
                    await writer.WriteLineAsync(line).ConfigureAwait(false);
                    if (completionTask.IsCompleted)
                        break;
                }
            }
            finally
            {
                writer?.Dispose();
            }
        }
        private static async Task WriteToChannel(Channel<string> channel)
        {
            using var reader = new StreamReader(_path);
            while (!reader.EndOfStream)
            {
                await Task.Delay(_writerDelayMs).ConfigureAwait(false);
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                channel.Writer.TryWrite(line);
            }
            channel.Writer.Complete();
        }

        public static void GenerateFile(int lineCount, string line, string path)
        {
            var content = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                content.Add(line);
            }
            File.WriteAllLines(path, content);
        }
    }
}
