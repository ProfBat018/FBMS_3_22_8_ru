# <editor-fold desc="While">

# while - пока
# while - цикл с условием!!!

# num = 0
#
# while num <= 10:
#     num += 1
#     print(num)


# </editor-fold>

# <editor-fold desc="While with if">

# start = int(input("Enter start: "))         # 1
# end = int(input("Enter end: "))             # 10
#
# # i - iteration (шаг цикла)
#
# i = start
# finish = end
#
# while i != finish:
#     print(i)
#     i += 1
#
# i = start
# finish = end
#
# while i != finish:
#     if i % 5 == 0:
#         print(i)
#     i += 1


# </editor-fold>

# <editor-fold desc="">

# num = 10
#
# while True:
#     print("Hello")
#     num -= 1


# </editor-fold>


start = int(input("Enter start: "))
end = int(input("Enter end: "))

if start > end:
    tmp = start
    start = end
    end = tmp

while start < end:
    print(start)
    start += 1
