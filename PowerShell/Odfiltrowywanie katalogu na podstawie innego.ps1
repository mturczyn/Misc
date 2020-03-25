<# Skrypt, ktory porownuje dwie lokaliizacje i odfiltrowuje (usuwa pliki), ktore nie sa w oryginalnej strukturze, tzn.
mamy dwa katalogi, tu nazwane root oraz drugi okreslony sciezka podawana do funkcji. Oba katalogi sa w tej samej lokalizacji.
Skrypt gwarantuje, ze w drugiej lokalizacji zostanie taka sama struktura jak w oryginalnym (tu roocie). #>

function filterFiles {
    $rootPath = $args[0];
    $rootCatalogName = $args[1];
    Write $rootPath
    Get-ChildItem $rootPath | ForEach-Object {
        <# sprawdzamy czy istnieje w naszym roocie, jesli nie, to usuwamy, jesli tak, to w przypadku pliku odpalamy rekurencyjnie #>
        if(Test-Path $_.FullName.Replace($rootCatalogName, "root")){            
            if(-Not (Test-Path -Path $_ -PathType Leaf)){
                <# odpalamy rekurencyjnie #>
                filterFiles $_.FullName $rootCatalogName;
            }
        }
        else {
            Remove-Item -Recurse -Path $_.FullName;
        }    
    }
}
<# sciezka do katalogu do odfiltrowania #>
$pathToRoot = 'C:\users\Michal\Desktop\root_original\';

$rootName = $pathToRoot.TrimEnd('\').Substring($pathToRoot.TrimEnd('\').LastIndexOf('\') + 1)
filterFiles $pathToRoot $rootName;