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
    Add UnaryMinus name -(Cos)
Типы фунций:
U – UnaryMinus
Af – AdditionsOfFunctions
Sf – SubtractionOfFunctions
Fc – FunctionComposition
P – Polynomial (Polynom)
L – Linear
Cos - Cos
Sin – Sin
Сложные функции:
Add Name af cos + fc sin(p x^3+2)
Add Name sf p x^4+1 – l x
Add Name u -(af cos + sin)
Add Name fc sin(cos)
Команда удаления функции из хранилища - Delete Название_функции (Delete name)
Команда переименования функции - Rename Текущее_название Новое_название (Rename name newname)
Команда Вычисления производной и добавления новой функции в хранилище - Derivative Название функции (Derivative Name)
Команда вычисления значения функции в точке - Название_функции(Точка) (Name(1))

