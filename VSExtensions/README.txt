Jak zainstalowa� rozszerzenie?
W katalogach, gdzie l�duj� skompilowane pliki (foldery Release albo Debug) s� pliki o rozszerzeniu vsix. S� to instalatory rozszerzenia, kt�ra nale�y uruchomi�.

Jak testowa� rozszerzenie?
1. Testuj�c rozszerzenie uruchamiana jest eksperymentalna instancja Visuala, kt�r� od czasu do czsau nale�y wyczy�ci� (poniewa� s� tam dodawane nasze wtyczki/rozszerzenia i za ka�dym razem):
Menu start => Visual Studio 2019 => Reset the Visual Studio 2019 Experimntal Instance
Ewentualnie mo�na sobie wygooglowa� jak to si� robi (je�li powy�sze nie b�dzie dzia�a�).
2. W kataogu solucji mamy dodatkowy katalog TestSolution, na kt�rej powinni�my testowa� to rozszerzenie (ma on tak� sam� struktur� jak nasz projekt HUF).

W solucji mamy projekt Test, gdzie testujemy sobie samo okno do t�umacze� (�eby nie odpala� eksperymentalnej instancji VS). Jest tam skrypt pre-buildowy, kt�ry przepisuje kod okna z projektu
rozszerzenia do projektu test�w, tak aby mie� aktualne okno.