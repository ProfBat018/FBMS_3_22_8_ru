"""
Function - callable part of code
def - keyword stands for definition

def functionName(parameters):
    code....


after and before a function, we have to put two blank lines
function should be lowercase
"""


def sayhello():
    print("Hello")


def find_even(number: int):
    if number % 2 == 0:
        print("Even")
    else:
        print("odd")


def find_even2(number: int):
    if number % 2 == 0:
        return True
    else:
        return False


def power(num, degree):
    res = 1
    for i in range(degree):
        res *= num
    return res


num = int(input("Enter number: "))

print(power(num, 3))

# result = find_even2(num)
# print(result)

