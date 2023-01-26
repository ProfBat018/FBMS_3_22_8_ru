# <editor-fold desc="Map">

# <editor-fold desc="Without map">

# def find_even(data: list):
#     result = list()
#     for i in range(len(data)):
#         if data[i] % 2 == 0:
#             result.append(True)
#         else:
#             result.append(False)
#     return result
#
#
# nums = [1, 2, 3, 4, 5]
#
# nums_res = find_even(nums)
# print(nums_res)

# </editor-fold>

# <editor-fold desc="My Map">


# def find_even(num):
#    return num % 2 == 0
#
#
# def my_map(function, collection):
#     res = []
#     for i in collection:
#         res.append(function(i))
#     return iter(res)
#
#
# nums = [5, 4, 3, 2, 1]
#
# result = my_map(find_even, nums)
#
# result = list(result)
# print(result)

# </editor-fold>

# <editor-fold desc="With Map Part 1">

# def find_even(num):
#     return num % 2 == 0
#
#
# nums = [1, 2, 3, 4, 5]
#
# res = map(find_even, nums)
# print(list(res))

# res = map(find_even, nums)

# </editor-fold>

# <editor-fold desc="With Map Part 2">

# nums = [1, 2, 3, 4, 5]
#
# result = map(lambda num: num % 2 == 0, nums)
#
# result = list(result)
# print(result)

"""
 lambda num: num % 2 == 0 - ANONYMOUS FUNCTIONS 
 
 num - parameter of function. 
"""

# </editor-fold>


# </editor-fold>

# <editor-fold desc="Filter">

# nums = [1, 2, 3, 4, 5]
#
# result = list(filter(lambda x: x % 2 == 0, nums))
#
# print(result)


# </editor-fold>

# <editor-fold desc="Reduce">

import functools    # functools - functional tools

# <editor-fold desc="my reduce">


# def my_reduce(function, collection):
#     iterator = iter(collection)
#
#     value = next(iterator)
#
#     for item in iterator:
#         value = function(value, item)
#
#     return value
#
#
# names = ["Elvin", "Agasef", "Elnur", "Abulfat", "Kenan", "Muhammad"]
#
# res = my_reduce(lambda a, b: a if (len(a) > len(b)) else b, names)
# print(res)

# </editor-fold>


# <editor-fold desc="Reduce part 1 ">



# nums = [i for i in range(1, 11)]
#
# result = functools.reduce(lambda n1, n2: n1 + n2, nums)
# print(result)

# </editor-fold>

# <editor-fold desc="Reduce part 2">

# names = ["Elvin", "Agasef", "Elnur", "Abulfat", "Kenan"]
#
# это условное выражение называется - тернарное выражение
# max_len = functools.reduce(lambda a, b: a if (len(a) > len(b)) else b, names)
#
# print(max_len)

# </editor-fold>




# </editor-fold>


