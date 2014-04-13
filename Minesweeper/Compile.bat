cd C:\Program Files (x86)\Microsoft Visual Studio 10.0\VC\
call vcvarsall.bat
cd C:\Minesweeper\Minesweeper\Minesweeper
resgen CellElement.resx CellElement.resources
resgen MainForm.resx Minesweeper.MainForm.resources
resgen Settings.resx Minesweeper.Settings.resources
cd C:\Minesweeper\Minesweeper\Minesweeper\Properties
resgen Resources.resx Minesweeper.Properties.Resources.resources
cd C:\Minesweeper\Minesweeper\Minesweeper
csc /target:winexe /out:MyBuild\Program.exe *.cs Properties\*.cs /res:Minesweeper.MainForm.resources /res:CellElement.resources /res:Minesweeper.Settings.resources /res:Properties\Minesweeper.Properties.Resources.resources
pause