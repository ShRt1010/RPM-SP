class Reader:
    def __init__(self, full_name, ticket_number):
        self.full_name = full_name
        self.ticket_number = ticket_number

    def show_info(self):
        print(f"Читатель: {self.full_name}, билет: {self.ticket_number}")


class Book:
    def __init__(self, title, author, year):
        self.title = title
        self.author = author
        self.year = year

    def show_info(self):
        print(f"Книга: {self.title}, автор: {self.author}, год: {self.year}")


# Наследуюсь от класса Book
class LibraryBook(Book):
    def __init__(self, title, author, year, shelf_number):
        super().__init__(title, author, year)
        self.shelf_number = shelf_number
        self.is_taken = False
        self.reader_name = "-"

    def issue_to_reader(self, reader):
        if not self.is_taken:
            self.is_taken = True
            self.reader_name = reader.full_name
            print(f'Книга "{self.title}" выдана: {self.reader_name}')
        else:
            print(f'Книга "{self.title}" уже выдана')

    def return_to_library(self):
        if self.is_taken:
            print(f'Книга "{self.title}" возвращена')
            self.is_taken = False
            self.reader_name = "-"
        else:
            print(f'Книга "{self.title}" уже в библиотеке')

    # Здесь переопределяю метод родителя
    def show_info(self):
        status = "выдана" if self.is_taken else "в библиотеке"
        print(
            f"Библиотечная книга: {self.title}, автор: {self.author}, год: {self.year}, "
            f"полка: {self.shelf_number}, статус: {status}, читатель: {self.reader_name}"
        )


reader1 = Reader("Иванов Кирилл", "RB-102")
reader1.show_info()
print()

book1 = Book("Мастер и Маргарита", "М. Булгаков", 1967)
book1.show_info()
print()

library_book = LibraryBook("Преступление и наказание", "Ф. Достоевский", 1866, "A-12")
library_book.show_info()
print()

library_book.issue_to_reader(reader1)
library_book.show_info()
print()

library_book.return_to_library()
library_book.show_info()
