$sign = @' 
      [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
      public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
'@
Add-Type -AssemblyName System.Windows.Forms
$x = [System.Windows.Forms.Cursor]::Position.X
$y = [System.Windows.Forms.Cursor]::Position.Y

$SendMouseClick = Add-Type -memberDefinition $sign -name "Win32MouseEventNew" -namespace Win32Functions -passThru     
# $SendMouseClick::mouse_event(0x0008, $x, $y, 0, 0);
$SendMouseClick::mouse_event(0x0010, $x, $y, 0, 0);