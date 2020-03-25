Jak zainstalowaæ rozszerzenie?
W katalogach, gdzie l¹duj¹ skompilowane pliki (foldery Release albo Debug) s¹ pliki o rozszerzeniu vsix. S¹ to instalatory rozszerzenia, która nale¿y uruchomiæ.

Jak testowaæ rozszerzenie?
1. Testuj¹c rozszerzenie uruchamiana jest eksperymentalna instancja Visuala, któr¹ od czasu do czsau nale¿y wyczyœciæ (poniewa¿ s¹ tam dodawane nasze wtyczki/rozszerzenia i za ka¿dym razem):
Menu start => Visual Studio 2019 => Reset the Visual Studio 2019 Experimntal Instance
Ewentualnie mo¿na sobie wygooglowaæ jak to siê robi (jeœli powy¿sze nie bêdzie dzia³aæ).
2. W kataogu solucji mamy dodatkowy katalog TestSolution, na której powinniœmy testowaæ to rozszerzenie (ma on tak¹ sam¹ strukturê jak nasz projekt HUF).

W solucji mamy projekt Test, gdzie testujemy sobie samo okno do t³umaczeñ (¿eby nie odpalaæ eksperymentalnej instancji VS). Jest tam skrypt pre-buildowy, który przepisuje kod okna z projektu
rozszerzenia do projektu testów, tak aby mieæ aktualne okno.