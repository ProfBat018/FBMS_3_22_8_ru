def check_even(num):
    return num % 2 == 0


def check_even_range(nums: list):
    for i in range(len(nums)):
        nums[i] = nums[i] % 2 == 0
    return nums


def check_even_range2(*nums):
    nums = list(nums)
    for i in range(len(nums)):
        nums[i] = nums[i] % 2 == 0
    return nums


def check_even_range3(nums: tuple):
    nums = list(nums)
    for i in range(len(nums)):
        nums[i] = nums[i] % 2 == 0
    return nums


def check_even_range4(**nums):
    if nums['first'] == 1:
        print(nums)


def check_even_range5(nums: dict):
    if nums['first'] == 1:
        print(nums)


# print(check_even_range3((1, 2, 3, 4, 5)))
# check_even_range4(first=1, second=2, third=3)
# check_even_range5({'first': 1, 'second': 2, 'third': 3})
# print(check_even_range2(1, 2, 3, 4, 5))
# print(check_even_range([1, 2, 3, 4, 5]))
# check_even(1)



