# <editor-fold desc="Task 1">

# start = int(input("Enter first number: "))
# end = int(input("Enter second number: "))

# if start > end:
#     tmp = start
#     start = end
#     end = tmp

# if start > end:
#     start, end = end, start     # синтактический сахар
#
#
# while start <= end:
#     print(start)
#     start += 1

# </editor-fold>

# <editor-fold desc="Task 2">
# 12345

# number = int(input("Enter your number: "))
# division = 1
#
# while (number // division) > 0:
#     digit = (number // division) % 10
#     division *= 10
#     print(digit)

# </editor-fold>

# <editor-fold desc="Task 3">

# number = int(input("Enter your number: "))      # 1234
# division = 1
#
# while (number // division) != 0:
#     division *= 10
#
# division //= 10
#
# while division >= 1:
#     print((number // division) % 10)
#     division //= 10

# </editor-fold>

# <editor-fold desc="Task 4">

# number = int(input("Enter your number: "))
# division = 1
# result = 0
#
# while (number // division) > 0:
#     digit = (number // division) % 10
#     division *= 10
#     result = (result * 10) + digit
#
# print(result)

# </editor-fold>

# <editor-fold desc="Task 5">

# number = int(input("Enter your number: "))      # 1234
# division = 1
# result = 0
#
# while (number // division) != 0:
#     division *= 10
#
# division //= 10
#
# while division >= 1:
#     digit = (number // division) % 10
#     division //= 10
#     result = (result * 10) + digit
#
# print(result)

# </editor-fold>



