"""
List - это изменяемый тип данных, который хранит набор из элементов разного типа
List создается с помощью брекетов "[]"
Ключевое слово - list()
"""

"""
Методы:
   append()	-   Adds an element at the end of the list
   clear()	-   Removes all the elements from the list
   copy()	-   Returns a copy of the list
   count()	-   Returns the number of elements with the specified value
   extend()	-   Add the elements of a list (or any iterable), to the end of the current list
   index()	-   Returns the index of the first element with the specified value
   insert()	-   Adds an element at the specified position
   pop()	-   Removes the element at the specified position
   remove()	-   Removes the first item with the specified value
   reverse()-   Reverses the order of the list
   sort()   -   Sorts the list
"""

# names = []
# print(names)
# names.append("Elvin")
# names.append("Vaqif")
# print(names)

# names = ["Elvin", "Kenan"]
# print(names)
# names.clear()
# print(names)

# names = ["Elvin", "Kenan"]
# tmp = names     #  Поверхностное копирование. Shallow copy
# tmp.append("Ziya")
# print(names)


# names = ["Elvin", "Kenan"]
# tmp = names.copy()     #  Глубокое копирование. Deep copy
# tmp.append("Ziya")
# print(names)
# print(tmp)


# names = ["Elvin", "Kenan"]
# result = names.count("Elvin")
# print(result)

# names = ["Elvin", "Kenan"]
# surnames = ["Azimov", "Mammadli"]
# names.extend(surnames)
# print(names)
# names = names + surnames
# print(names)


# names = ["Elvin", "Kenan"]
# print(names.index("Elvin"))

# names = ["Elvin", "Kenan"]
# names.insert(0, "Elnur")
# print(names)


# names = ["Elvin", "Kenan"]
# names.pop()
# print(names)

# names = ["Elvin", "Kenan"]
# names.pop(0)
# print(names)

# names = ["Elvin", "Kenan", "Elvin"]
# names.remove("Elvin")
# print(names)

# names = ["Elvin", "Kenan"]
# names.sort(reverse=True)
# print(names)

# names = ["Elvin", "Kenan", "Elnur"]
# names.sort()
# names.reverse()
# print(names)



