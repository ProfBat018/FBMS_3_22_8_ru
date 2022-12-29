# import string
# from random import choice
# from pyperclip import copy
#
# MIN_LENGTH = 8
# password = str()
#
# lower_letters = string.ascii_lowercase
# upper_letters = string.ascii_uppercase
# digits = string.digits
# punctuation = string.punctuation
#
# length = int(input("Enter length of password: "))
#
# if length < MIN_LENGTH:
#     length = MIN_LENGTH
#
# i = 0
# while i != length:
#     tmp = choice(lower_letters) + choice(upper_letters) + choice(digits) + choice(punctuation)
#     character = choice(tmp)
#     password += character
#     i += 1
#
# print(f"Your password is: {password}")
#
# while True:
#     choice = input("Enter Y for copy password or N for exit")
#     if choice == "Y":
#         copy(password)
#         break
#     elif choice == "N":
#         break
#
# print("Bye")
