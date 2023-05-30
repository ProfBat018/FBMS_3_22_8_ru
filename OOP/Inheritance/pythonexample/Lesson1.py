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



a = Transport("Car", 100)
b = Car("Car", 100, "red")

a.move()
b.move()




