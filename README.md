# ActorSystem

Actor System is a system that aims to reduce compliance with the Unity API by reducing the need to write logic and mechanics in MonoBehaviour.
The advantage of decoupling is the separation of responsibilities in addition to allowing the code to be testable and mockable in an easier and more efficient way.

The Actor System has two basic concepts:

- ActorMonoBehaviour: It is the class that will inherit from MonoBehaviour and will be the physical representation of the object in the scene, as if it were a **Body**.
- Actor: It is the class that owns the logic/mechanics of this object, representing the **Soul** of this entity.

The **Actor (Soul)** will have a **ActorMonoBehaviour(Body)**, when making this combination the object gains "life", that is, the Soul is controlling the Body.

**Example:**

In a Tower Defense game we have like Towers and we can represent them using the Actor System.

`````csharp
public class TowerEntity : ActorMonoBehaviour
{
//All tower code for visual effects, like particles, animations, etc.
}
****
public class Tower : Actor<Tower, TowerEntity>
{
//All tower logic/mechanics, like combat system to receive and do damage
}
`````

In the Tower class constructor method you must pass which prefab will be used for Body and a GameObject will automatically be generated.

Even though the Tower class is not a MonoBehaviour, most methods such as Awake, Start and Update will be available, you just need to override these methods and their operation will be very similar.

## Features
- Decoupling MonoBehaviour, similar to its methods in a pure C# class
- Body allocation is integrated with the Pool system

## To Be Implemented
- A table of Type per Prefab, to centralize and automate the relationship between Body and Soul without having to pass the body Prefab to the Soul constructor method.
- Integration with Odin Inspector

## Notes:
- The virtual methods that simulate MonoBehaviour are only called when the soul is possessing a body.
- Be careful with the life cycle of the soul and body, they can be created/destroyed individually, check Actor's methods to do this correctly.
- If you consider manipulating the soul outside the Main Thread, remember that Unity does not support the interaction of a Background Thread with the Engine, therefore changing the position of the soul in a Background Thread will cause errors.
