# Напишем программу. Угадай число.
# <editor-fold desc="First method">

# import random
#
# number = random.randint(1, 100)
# turns = 0
#
# while True:
#     res = int(input("Enter your number: "))
#     turns += 1
#     if res < number:
#         print("Your number is lower")
#     elif res > number:
#         print("Your number is bigger")
#     else:
#         print(f"You win with turns: {turns}")
#         break

# </editor-fold>

# <editor-fold desc="Second method">

# import random
#
# number = random.randint(1, 100)
# print(number)
# res = int(input("Enter your number: "))
#
#
# while res != number:
#     if res < number:
#         print("Your number is lower")
#     elif res > number:
#         print("Your number is bigger")
#     res = int(input("Enter your number: "))
#
# print(f"You win with")

# </editor-fold>


# Напишем программу, которая будет генерировать пароли для нас.

import string   # не путать с типом данных string
from random import choice

MIN_LENGTH = 8
password = str()

lower_letters = string.ascii_lowercase
upper_letters = string.ascii_uppercase
digits = string.digits
punctuation = string.punctuation

length = int(input("Enter length of password: "))

if length < MIN_LENGTH:
    length = MIN_LENGTH

i = 0
while i != length:
    tmp = choice(lower_letters) + choice(upper_letters) + choice(digits) + choice(punctuation)
    character = choice(tmp)
    password += character
    i += 1

print(password)
