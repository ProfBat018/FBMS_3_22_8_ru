#  If Conditions
import time

# <editor-fold desc="Conditions">

# num1 = int(input("Enter first number: "))
# num2 = int(input("Enter first number: "))

# <editor-fold desc="IF keyword">

# if num1 == num2:
#     print(num1)
# if num1 > 0:
#     print(num1)

# </editor-fold>

# <editor-fold desc="Else keyword">

# if num1 == num2:
#     print("Yes")
# else:
#     print("No")

# if num1 == num2:
#     print(f"{num1} == {num2}")
# if num1 > num2:
#     print(f"{num1} > {num2}")
# else:
#     print("No")


# </editor-fold>

# <editor-fold desc="Elif keyword">

# if num1 == num2:
#     print(f"{num1} == {num2}")
# else:
#     if num1 > num2:
#         print(f"{num1} > {num2}")
#     else:
#         if num1 < num2:
#             print(f"{num1} < {num2}")

# if num1 == num2:
#     print(f"{num1} == {num2}")
#     print("{} == {}".format(num1, num2))
# elif num1 > num2:
#     print(f"{num1} > {num2}")
# elif num1 < num2:
#     print(f"{num1} < {num2}")

# </editor-fold>

# </editor-fold>

#
# choice = int(input("1. Addition\n"
#                    "2. Subtraction\n"
#                    "3. Multiplication\n"
#                    "4. Division\n"))
#
# first_num = int(input("Enter first number: "))
# second_num = int(input("Enter second number: "))
#
# if choice == 1:
#     print(first_num + second_num)
# elif choice == 2:
#     print(first_num - second_num)
# elif choice == 3:
#     print(first_num * second_num)
# elif choice == 4:
#     print(first_num / second_num)
# else:
#     print("invalid input")

num1 = 1
num2 = 6

if num1 > 0 and num2 < 10:
    print("Yes")

if num1 > 0 or num2 < 10:
    print("Yes")
