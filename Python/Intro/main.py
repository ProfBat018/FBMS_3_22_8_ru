# <editor-fold desc="Print description">

# print("Hello")
# print("World")

# print("Hello World")
# print("Hello", "World")
# print(1, 2, 3, 4, 5, sep=' ')

# print("Hello", end='👽')  # end - это endline
# print("World")

# </editor-fold>

# <editor-fold desc="Escape Sequences">

# \n - newline
# \t - TAB
# \a - alert
# \\ - \
# \" - "
# \' - '


# print("Hello\nWorld")
# print("Hello\tWorld")
# print("Hello\\\\World")

# print("'Случайности не случайны'")
# print('"Случайности не случайны"')

# print("\"Случайности не случайны\"")
# print('\'Случайности не случайны\'')

# </editor-fold>

# <editor-fold desc="Variables">
# Variable - переменная
#
# number1 = 5
# number2 = 6
#
# print(number1, "+", number2, "=", number1 + number2)
# print(f"{number1} + {number2} = {number1 + number2}")   # f - format. String Interpolation
# print("{} + {} = {}".format(number1, number2, number1 + number2))   # trivial version
#
# print("{number1} + {number2} = {number1 + number2}")

# print(number1 + number2)

# </editor-fold>

# <editor-fold desc="Variable naming cases">


# computer_collection is Snake Case. Most familiar to python
# ComputerCollection is Pascal Case
# computerCollection is Camel Case

"""
variations of Camel Case.
1. Upper Camel Case, which the same thing as Pascal Case.
ComputerCollection, FirstName
2. Lower Camel Case.
computerCollection
"""

# first-num

# first_num = 5
# second_num = 10

# print(first_num + second_num)

# </editor-fold>

# <editor-fold desc="Data Types">

'''
    1. String. (str). Any symbol or text
    2. Integer. (int). Any integer value
    3. Float. (float). Any number with floating point.
    4. Bool. (bool). Logical data type. Full name is boolean.
'''

# </editor-fold>

# <editor-fold desc="Data Input">

# input enters string data type by default


first_num = input("Enter first number: ")
second_num = input("Enter second number: ")

print(type(first_num))
print(type(second_num))

first_num = int(first_num)
second_num = int(second_num)

print(type(first_num))
print(type(second_num))

print(first_num + second_num)
print(first_num * second_num)
print(first_num / second_num)


# </editor-fold>


