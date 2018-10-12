Данная программа используется для работы с математическими функциями, такими как:
 -Косинус(Cos)
 -Синус(Sin)
 -Многочлен(Polynom,Polynomial)
 -Линейная функция(Linear)
 Дополнительные функции :
 -Унарный минус(UnaryMinus)
 -Сложение функций (AdditionOfFunctions)
 -Вычитание функций (SubtractionOfFunctions)
 -Композиция функций (FunctionComposition)
Грамматика:
Команда добавления функции в хранилище - Add Название_функции Тип_функции Функция
Ex: Add name Cos
    Add name Polynom x^4-x^2+1
    Add name Sin
    Add Linear name 3x+5
    Add UnaryMinus name -(f name2)
	Add Name af f name2 + f name3
    Add Name sf f name2 – f name3
    Add Name u -(name2)
    Add Name fc name2(name3)
Типы фунций:
U – UnaryMinus
Af – AdditionsOfFunctions
Sf – SubtractionOfFunctions
Fc – FunctionComposition
P – Polynomial (Polynom)
L – Linear
Cos - Cos
Sin – Sin
Команда удаления функции из хранилища - Delete Название_функции (Delete name)
Команда переименования функции - Rename Текущее_название Новое_название (Rename name newname)
Команда Вычисления производной и добавления новой функции в хранилище - Derivative Название функции (Derivative Name)
Команда вычисления значения функции в точке - Название_функции(Точка) (Name(1))

