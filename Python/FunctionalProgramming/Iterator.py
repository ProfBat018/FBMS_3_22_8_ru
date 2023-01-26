nums = [1, 2, 3, 4, 5]

nums_iterator = iter(nums)
print(nums_iterator)

print(next(nums_iterator))
print(next(nums_iterator))
print(next(nums_iterator))
print(next(nums_iterator))
print(next(nums_iterator))

for i in nums:
    print(i)
