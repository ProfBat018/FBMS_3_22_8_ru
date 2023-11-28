// Абстрактная фабрика 

using AbstractFactory.Entities.Classes.Characters;
using AbstractFactory.Entities.Interfaces;
using AbstractFactory.Fabrics;
using AbstractFactory.Fabrics.Classes;

ICharacterFabric fabric = new HumanFabric();

IEntity entity = fabric.CreateCharacter(new Healer());
IHealer healer = entity.Character as IHealer;

healer.MassHeal();

