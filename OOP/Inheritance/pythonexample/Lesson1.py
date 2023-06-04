'''
Модификаторы доступа:
    public - доступен везде
    protected - доступен внутри класса и в классах наследниках
    private - доступен только внутри класса

Все, что начинается с __ считается приватным
Чтобы сделать protected, нужно поставить один _
Чтобы сделать public, нужно не ставить ничего
'''


class Transport:
    def __init__(self, name, speed):
        self.name = name
        self.speed = speed

    def move(self):
        print(self.name + " is moving with speed " + str(self.speed))


class Car(Transport):
    def __init__(self, name, speed, color):
        Transport.__init__(self, name, speed)
        self.color = color

    def move(self):
        print(self.name + " is moving with speed " + str(self.speed) + " and color " + self.color)

    def __str__(self):
        return self.name + '\t' + str(self.speed) + '\t' + self.color



b = Car("Car", 100, "red")
print(b)

num = 5
print(num.__str__())






