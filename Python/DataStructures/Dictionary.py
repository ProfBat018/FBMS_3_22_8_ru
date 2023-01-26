"""
    Dictionary - Словарь
    Работает по принципу hash table, где первый параметр это ключ, а второй это значение.
    Ключевое слово dict
    В словаре нет индексации, то есть вы не можете написать users[0]
"""

"""
    clear()	        Removes all the elements from the dictionary
    copy()	        Returns a copy of the dictionary
    fromkeys()	    Returns a dictionary with the specified keys and value
    get()	        Returns the value of the specified key
    items()	        Returns a list containing a tuple for each key value pair
    keys()	        Returns a list containing the dictionary's keys
    pop()	        Removes the element with the specified key
    popitem()	    Removes the last inserted key-value pair
    setdefault()	Returns the value of the specified key. If the key does not exist: insert the key, with the specified value
    update()	    Updates the dictionary with the specified key-value pairs
    values()	    Returns a list of all the values in the dictionary
"""


# <editor-fold desc="Part 1">



# users = {
#     "Elvin": "Elvin Azimov",
#     "Ziya": "Ziya Hacili",
#     "Elnur": "Elnur Mammadov"
# }

# print(users)
# print(users["Elvin"])

# </editor-fold>

# <editor-fold desc="Part 2 ">


# print(users["Elvin"])
# users["Elvin"] = "Hakuna Matata"
# print(users["Elvin"])

# users = {
#     13: "Elvin",
#     3.25: "Azimov",
#     "Foo": "aaa"
# }


# print(users["Foo"], users[13])

# </editor-fold>

# <editor-fold desc="Part 3">

# users = {
#     1: ["Elvin", "Azimov", 21, (12, 7, 9, 12)],
#     2: ["Elnur", "Mammadov", 18, (12, 10, 10, 11)]
# }

# print(users[1])
# print(users[2])

# first = users[1]
# print(first[2][0])

# </editor-fold>

# <editor-fold desc="Part4">

users = {1: "Elvin", 2: "Azimov"}

# users[3] = "dghdfg"
# print(users)

# users2 = users.fromkeys([1, 2, 3, 4], "Foo")
# print(users2)


# print(users[1])
# print(users.get(1))

# res = list(users.items())
# print(res)
# print(res[0])
# print(res[1])

# keys = tuple(users.keys())
# values = tuple(users.values())
#
# print(keys)
# print(values)

# users.pop(2)
# print(users)

# users.popitem()
# print(users)

# a = users.setdefault(3, "a")
# print(a)
# print(users)

# def foo(**kwargs):
#     print(kwargs)
#
#
# foo(a=1, b=2, c=3)


# print(users)
# users.update(a=3)
# print(users)

# </editor-fold>

