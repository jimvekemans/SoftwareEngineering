# Strategy Pattern: Basic Idea

`Strategy Design Pattern` is a type of behavioral design patterns that encapsulates a "family" of algorithms and selects one from the pool for use during runtime. The algorithms are interchangeable, meaning that they are substitutable for each other.

> *The strategy pattern is a behavioral design pattern that enables selecting an algorithm at runtime — Wikipedia*

The key idea is to create objects which represent various strategies. These objects form a pool of strategies from which the context object can  choose from to vary its behavior as per its strategy. These  objects(strategies) perform the same operation, have the same(single)  job and compose the same interface strategy.

Let’s take the sorting algorithms we have for example. Sorting algorithms  have a set of rule specific to each other they follow to effectively  sort an array of numbers. We have the

- Bubble Sort
- Linear Search
- Heap Sort
- Merge Sort
- Selection Sort

to name a few.

Then, in our program, we need different sorting algorithms at a time during  execution. Using SP allows us to group these algorithms and select from  the pool when needed.

It is more like a plugin, like the PlugnPlay in Windows or in the Device  Drivers. All the plugins must follow a signature or rule.

For example, a Device Driver could be anything, Battery Driver, Disk Driver, Keyboard Driver …

They must implement:

```
NTSTATUS DriverEntry (_In_ PDRIVER_OBJECT ob, _In_ PUNICODE_STRING pstr) {
    //...
}VOID DriverUnload(PDRIVER_OBJECT DriverObject)
{
    RtlFreeUnicodeString(&servkey);
}NTSTATUS AddDevice(PDRIVER_OBJECT DriverObject, PDEVICE_OBJECT pdo)
{
    return STATUS_SOMETHING; // e.g., STATUS_SUCCESS
}
```

Every driver must implement the above functions, the DriverEntry is used by  the OS when loading a driver, the DriverUnload when removing the driver  from memory, the AddDriver for adding the driver to the driver list.

The OS doesn’t need to know what your driver does, all it knows that since  you called it a driver it will assume all those are present and will  call them at the required time.

If we lump the sorting algorithms in one class we will find ourselves writing conditional statements to select one algorithm.

Most importantly, all the strategies must have the same signature. If you  are using an OO-Language make sure the strategies inherit from a common  interface, if using a non-OO-Language like JavaScript, make sure the  strategies have a common method to call by the context.

```
// In an OOP Language -
// TypeScript// interface all sorting algorithms must implement
interface SortingStrategy {
    sort(array);
}// heap sort algorithm implementing the `SortingStrategy` interface, it implements its algorithm in the `sort` method
class HeapSort implements SortingStrategy {
    sort() {
        log("HeapSort algorithm")
        // implementation here
    }
}// linear search sorting algorithm implementing the `SortingStrategy` interface, it implements its algorithm in the `sort` method
class LinearSearch implements SortingStrategy {
    sort(array) {
        log("LinearSearch algorithm")
        // implementation here
    }
}class SortingProgram {
    private sortingStrategy: SortingStrategy
    constructor(array: Array<Number>) {    }
    runSort(sortingStrategy: SortingStrategy) {
        return this.sortingStrategy.sort(this.array)
    }
}// instantiate the `SortingProgram` with an array of numbers
const sortProgram = new SortingProgram([9,2,5,3,8,4,1,8,0,3])// sort using heap sort
sortProgram.runSort(new HeapSort())// sort using linear search
sortProgram.runSort(new LinearSearch())
```

Quite straight, we have an interface that all sorting algorithms must abide  by. The SortingProgram takes a SortingStrategy as param in its runSort  and calls the sort method. Any concrete implementation of the `SortingStrategy` must implement the `sort` method.

You see SP supports the [SOLID principles](https://blog.bitsrc.io/solid-principles-every-developer-should-know-b3bfa96bb688) and forces us to abide by it. The D in SOLID says we must depend on  abstractions, not on concretions. That’s what happened in the runSort  method. Also the O, which says entities should be open for, not  extension.

If we had taken an alternative of subclassing our sorting algorithms, we  will eventually run into a code that is hard to understand and maintain  because we will have many related classes with the difference being on  the algorithms they carry. The I, we have one specific interface for the concrete strategy to implement.

It isn’t bogus just specific to the job because any sorting algorithm will have to run the sort to sort:). The S, all the classes implementing the strategy have only one job of sorting. The L, all subclasses of the  concrete strategies are substitutable for their superclasses.

So we see truly, that we can select algorithms in runtime using the SP and it helps us build extensible frameworks.

# Structure

![img](https://miro.medium.com/max/30/1*4vdmSjQVWuBF7C2ZGelfYA.png?q=20)

![img](https://miro.medium.com/max/804/1*4vdmSjQVWuBF7C2ZGelfYA.png)

In the figure above, the `Context` class depends on the `Strategy`. During execution or runtime, different strategies of `Strategy` type are passed to the `Context` class. The Strategy provides the template by which the strategies must abide by for implementation.

![img](https://miro.medium.com/max/30/1*9hN9PDGic_nmL4VOL-B73Q.png?q=20)

![img](https://miro.medium.com/max/1287/1*9hN9PDGic_nmL4VOL-B73Q.png)

In the above UML class diagram, the Concrete class depends on an  abstraction, Strategy interface. It doesn’t implement the algorithm  directly. The Context from its method `runStraegy` calls the doAlgorithm in the Strategy concretion passed to it. The  Context class is independent of the method and doesn't know and doesn't  need to know how the doAlgorithm method is implemented. By virtue of `Design by Contract`, the class implementing the Strategy interface must implement the doAlgorithm method.

In strategy design pattern, there are three main entities: Context, Strategy, and ConcreteStrategy.

The **Context** is the body composing the concrete strategies where they play out their roles.

**Strategy** is the template that defines how all startegies must be configured.

**ConcreteStrategy** is the implementation of the Strategy template(interface).