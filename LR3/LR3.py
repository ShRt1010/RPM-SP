import pandas as pd

file_name = "lab3.xlsx"

# Создаем Excel-файл с несколькими листами
with pd.ExcelWriter(file_name) as writer:
    pd.DataFrame({
        "Имя": ["Иван", "Анна", "Олег"],
        "Возраст": [19, 20, 18],
        "Группа": ["ИСП-21", "ИСП-21", "ИСП-22"]
    }).to_excel(writer, sheet_name="Студенты", index=False)

    pd.DataFrame({
        "Товар": ["Мышь", "Клавиатура", "Монитор"],
        "Цена": [1200, 2500, 15000],
        "Количество": [5, 3, 2]
    }).to_excel(writer, sheet_name="Товары", index=False)

    pd.DataFrame({
        "Предмет": ["Python", "C#", "Базы данных"],
        "Оценка": [5, 4, 5]
    }).to_excel(writer, sheet_name="Оценки", index=False)

print("Первый лист:")
print(pd.read_excel(file_name))

print("\nЛист Товары, только 2 столбца и 2 строки:")
print(pd.read_excel(file_name, sheet_name="Товары", usecols=["Товар", "Цена"], nrows=2))

print("\nЛист Студенты с указанием типа данных:")
print(pd.read_excel(file_name, sheet_name="Студенты", dtype={"Возраст": "string"}))

print("\nСразу несколько листов:")
sheets = pd.read_excel(file_name, sheet_name=["Студенты", "Оценки"])
for name, table in sheets.items():
    print(f"\n{name}")
    print(table)
