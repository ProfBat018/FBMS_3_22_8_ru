"""
    Function - вызываемая часть кода.
    До и после функции должны быть 2 пустые строчки или 2 blank lines.
    Зачем нужна функция ? Функция предотвращает дублирование кода.
    Функция может быть void и также может возврашать какой-то тип данных.
    return действует на функцию, как break
    return возвращает данные на место вызова
    значение в параметры передаются по порядку
"""

# <editor-fold desc="Return">

# def find_even(num):
#     if num % 2 == 0:
#         print("even")
#     else:
#         print("odd")


# def find_even(num):     # num - декларация, какую переменную он должен принять
#     if num % 2 == 0:
#         return True
#     else:
#         return False


# def find_even(num):
#     return num % 2 == 0


# number = int(input("Enter number: "))
# result = find_even(number)
# print(result)


# </editor-fold>

# <editor-fold desc="Default parameters">


# def add(num1, num2, num3=10):
#     return num1 + num2 + num3

# print(add(1, 2, 3))

# def add(num1=1, num2, num3=10):
#     return num1 + num2 + num3


# print(add(3, 4, 5))


# def add(num1=1, num2=5, num3=10):
#     return num1 + num2 + num3


# print(add(6, 5, 20))          # argument
# print(add(num1=6, num3=20))     # keyword argument

# </editor-fold>

# <editor-fold desc="Tuple">

"""
    Tuple - кортеж.
    Кортеж - это неизменяемый тип данных
"""


# nums = (1, 2, 3, 4, 5)

# nums[0] = 10 - ошибка

# print(nums.count(1))
# print(nums.index(1))

# </editor-fold>

# <editor-fold desc="Endless arguments">


# def add(*nums):  # * - бесконечное кол-во параметров
#     addition_res = 0
#     for i in range(len(nums)):
#         addition_res += nums[i]
#     return addition_res
#
#
# print(add(1, 2, 3, 4, 5, 6, 5, 7, 6))

# </editor-fold>


# nums = [1, 2, 3, 4, 5]
#
# nums = tuple(nums)
#
# print(nums)


# def foo():
#     return 1, 2
#
#
# nums = foo()
# print(nums)

#
# num = 5
# while num:
#     num += 1
#     print(num)
#     if num % 2 == 0:
#         print("Hakuna")
#         continue
#     else:
#         print("Matata")
#         break
# print("42")


def foo(num):
    if num % 2 == 0:
        return True
    return False
