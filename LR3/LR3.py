import pandas as pd

# Создаю таблицу со студентами
students = pd.DataFrame({
    "Имя": ["Иван", "Петр", "Анна"],
    "Возраст": [18, 19, 18],
    "Оценка": [5, 4, 5]
})

# Создаю таблицу с товарами
products = pd.DataFrame({
    "Товар": ["Хлеб", "Молоко", "Сыр"],
    "Цена": [45, 80, 250],
    "Количество": [2, 1, 1]
})

# Создаю Excel-файл с двумя листами
with pd.ExcelWriter("data.xlsx") as writer:
    students.to_excel(writer, sheet_name="Студенты", index=False)
    products.to_excel(writer, sheet_name="Товары", index=False)

print("Файл Excel создан")


# Вывожу весь лист Студенты
df1 = pd.read_excel("data.xlsx", sheet_name="Студенты")
print("\nЛист Студенты:")
print(df1)


# Вывожу только некоторые столбцы
df2 = pd.read_excel("data.xlsx", sheet_name="Студенты", usecols=["Имя", "Оценка"])
print("\nТолько имя и оценка:")
print(df2)


# Вывожу только первые 2 строки
df3 = pd.read_excel("data.xlsx", sheet_name="Товары", nrows=2)
print("\nПервые две строки листа Товары:")
print(df3)


# Читаю сразу несколько листов
all_sheets = pd.read_excel("data.xlsx", sheet_name=["Студенты", "Товары"])
print("\nПрочитанные листы:")
print(all_sheets.keys())
