---
typora-copy-images-to: images
---

# Design Patterns

### Wat moet je kennen en kunnen? 

Design Patterns kunnen aan bod komen zowel in het schriftelijk  (gesloten boek) gedeelte als in het het praktische laptopgedeelte (open  boek).

Volgende Design Patterns zijn behandeld:

- Strategy
- Observer
- Decorator
- Factory
- Singleton
- Command
- Template Method
- Composite / Iterator
- State

##### Schriftelijk, gesloten boek

- Een Design Pattern kunnen defiëren: wat is het? UML klassendiagram tekenen en de verschillende klassen verklaren.
- Een Design Pattern kunnen herkennen aan de hand van voorbeeldcode en/of een voorbeeld UML diagram.
- Aan de hand van een probleembeschrijving een oordeelkundige keuze  kunnen maken tussen Design Patterns: welke zou je hier het best  toepassen en waarom?

##### Praktisch, laptop (C#)

- Een oefening waarbij via een probleembeschrijving een Design Pattern dient gekozen (zie voorbeeldvraag)
- Voorbeeldcode herwerken (refactoren) tot een (eventueel  opgelegde) Design Pattern gebruikt wordt. Bijvoorbeeld: herwerk dit  switch-statement zodat je een Command patroon gebruikt.

# Git

### Config
  - system level config: `git config --system` stored in <u>/etc/gitconfig</u>
  - user level config: `git config --global` stored in <u>~/.gitconfig</u>
  - repository level config: `git config` stored in <u>./.git/config</u>
  
    <img src="./images/image-20200115152349541.png" alt="contents of user-level gitconfig"  />

### Staging

  - Marking the files which have been modified (or selecting ones that are about to be modified)
  - `git status` to check the current modified / added / deleted files that are not staged. `git add` or `git rm` to add or remove the file / folder.
<img src="./images/image-20200115154543238.png" alt="image-20200115154543238" style="zoom: 80%;" />
> Use this to <u>split work into commits that relate to the same issue</u>. e.g. if you change both front- and backend files, split the modified files up into separate commits using add ./backend, committing, adding ./frontend and committing again. This makes it easier to trace issues back to the commit previous to the issue.
> To remove edits to a file you can use `git reset HEAD {filename}` if the file hasnt been staged yet. If the file has been staged, add `--hard` to the reset-command.

### Commits
There are 2 main ways to commit
  - `git commit` where the user provides a summary and a more detailed message explaining the changes to the file.
  - `git commit -m ""` where there is a short message supplied for the commitmessage
<img src="./images/image-20200115155445899.png" alt="example of committing with a short message" style="zoom:80%;" />
> If there are files that should have been committed previously, you can use `git commit --amend` to add them to the previous commit.
> `git revert {commitID}` to undo all changes to the version of chosen commit. Command creates a new commit with all the info of what got changed back.

##### Tagging
Tagging a commit makes the commit easily retraceable by assign a sort of "name" for a commit along with the usual hashcode for a commit.
- usage: `git tag -a {annotation} -m {tagmessage}`

### Branching

<u>View <a href="./Branching.md">Branching.md</a> for a complete explanation of local vs remote branches</u>

Branches are used to create (slightly) altered / newer / better versions of the codebase. **<u>Using branches makes sure that there is a safe space to work on unstable code</u>.** Usually you would create a new branch for every new feature that gets added. The `master`-branch gets created automatically and should be used for code that is ready for production. Oftentimes, the master-branch is updated when the new version of the `develop`-branch is deemed good enough to be considered as a MVP (Minimal Viable Product). When the code of a branch is finished, it gets **<u>merged</u>** into a branch that contains a more complete version of the codebase. A merge combines two branches into one by comparing the commits of each branch. Every new / modified file of branch 1 gets compared to the same file on branch 2. If the file is only on 1 of 2 branches, then it gets merged automatically. Whenever the file is on both branches and both branches have modified the file, then the modified content is compared. When the file is modified in other places, the code is usually merged without issue BUT when there is a different version of some code, then it is up to a **reviewer** to check which version should be kept for the merged result.
A branch can be re-based. Git does this by looking at the current base, and compares the last commit of the current base to the list of commits from the new base. If the new base directly builds on top of the old base, then a rebase does a Fast-Forward and no merge needs to happen. If there are differences between the commits that have happened to the old- and new bases then a merge happens that applies your current commits to the new base and uses that merged state as your new base.

> Explanation written by creator of Git (Linus Torvaldis)
> https://git-scm.com/book/en/v2/Git-Branching-Branches-in-a-Nutshell
> https://git-scm.com/book/en/v2/Git-Branching-Basic-Branching-and-Merging
> https://git-scm.com/book/en/v2/Git-Branching-Rebasing

<hr>

### Wat moet je kennen en kunnen? 

Git kan aan bod komen zowel in het schriftelijk (gesloten boek) gedeelte als in het praktisch laptopgedeelte (open boek).

##### Schriftelijk, gesloten boek

- Kort kunnen situeren waarom git bedacht is
- Git principes kunnen uitleggen: staging, commit, push, pull, merge, rebase, etc.
- De interne werking van git kunnen uitleggen en verklaren
- Kunnen schetsen welke workflows voor teams mogelijk zijn als je git gebruikt

##### Praktisch, laptop

Op het examen zou je een git repo gegeven kunnen hebben, waarover je een aantal vragen moet kunnen beantwoorden. Hierbij zal je  dagdagelijkse git commando's moeten gebruiken (je moet het gebruikte  commando noteren) en/of je inzicht in de interne werking van git moeten  aantonen. Bijvoorbeeld:

- Hoeveel branches zitten in deze repo?
- Hoeveel commits tel je?
- Wie heeft de meest recente commit gedaan?
- Merge branch A en branch B, wat voor soort merge was dit?
- Teken een eenvoudig object database die git voor deze repo bijhoudt
- enz.

# SOLID Principles

### **S: Single Responsibility Principle:** 

Each class should have only one purpose. It should not try to multi-task any more than it has to. It's not to say each class can only have one  function. It's like saying that in an office, let the secretary be the secretary, the security guard be the security guard and the doorman be the doorman. Bad things happen if  you try to combine all those duties and drop it on just one person.

### **O: Open Closed Principle:** 

When you write a class or function or library you should do it in a way that anyone else can easily build on to it, but not change it's core elements. If you are holding a barbecue and bring the steaks, always allow other people to bring things like condiments, salads, drinks, chips, knifes, forks, etc but never  allow anyone to get rid of your steaks and replace them with veggie burgers (emphasis on replace).

### **L: Liskov's Substitution Principle:** 

Simply put, any time you have a sub-type of something, that subtype should be 100% compatible with the original thing. This is usually not  an issue since a subtype is a specialized version of the more generic  thing. If you have a rectangle  class that has "width and "height" as properties and want to make a  square class, don't use "side length" as it's property. You should be able to put in a rectangle where you would normally put a square and everything should work. Instead just make "width" = "height". Alternatively: "If it looks like a duck, quacks like a duck, but needs batteries - you probably have the wrong abstraction".

### **I: Interface Segregation Principle:** 

This one says that only make the user implement whichever methods they  intend to use. A problem commonly found in interfaces, which are a  bundle of functions, which have a name, and defined inputs/outputs but  no code, and need the user to make code for them, or else it won't  compile. A bad interface is one that has too many functions for what the user wants. If you only intend to use a handful of relevent functions  but there are 100 others, that's 100 do nothing code snippets that need  to be added to your code. Instead you should split this up into it's  most relevant groups. If you are a mechanic that only offered two services, a complete overhaul of the  whole car top top bottom, or nothing at all, nobody would go to your  shop. Instead you should offer a brakes package, exhaust package, oil  changes, etc.

### **D: Dependency Inversion Principle:** 

High level modules shouldn't depend on low level modules, both should  depend on abstractions. Also abstractions should not depend on the small details, the details should depend on the abstractions. A good top  level module should be flexible regarding how it's lower level modules  operate and shouldn't have to assume a specific way of operating.  Likewise a low level module should not be concerned with which specific  top level module it's reporting to. Also both of these should not have  details that are specific to one or the other, just a specification that will suit any application. This  is usually accomplished by using an interface between the high level and low level. The high level can call the same function on all of the low  level modules, knowing that the input and output will always be of the  expected type and the low level reports to the interface using the same  logic. Suppose you work at a  company and you are a manager. You have a lot of things that need doing  and a lot of employees. Those employees don't work only for you, they  have other managers. Instead of teaching them how to do their reports  specifically for your case, you should teach them the basic principles  of that report, and do the formalization yourself. From an employee's  point of view, It gets overwhelming to memorize every managers  preferences. It would be much easier if they can just write a generic  report for everyone with a certain set of data. In this case the generic report process is the interface. All you need is the data and you know  what the output should look like. By doing this, you as a manager aren't reliant on having your employees  give their reports in a super specific fashion (you'd have to proof read anyway). You as a manager can simply give them the data and get  cracking. If those employees have to give that report to anyone else,  they won't be confused by the twists you put on yours. As an employee it allows you to work for multiple managers using only a simple set of  rules, rather than memorizing a huge stack of little details. Everyone  wins.

<hr>

### Wat moet je kennen en kunnen? 

SOLID kan aan bod komen zowel in het schriftelijk (gesloten boek) als in het praktische gedeelte (open boek).

##### Schriftelijk, gesloten boek

- De SOLID principes kunnen opsommen en kort beschrijven
- Op basis van gedrukte broncode op papier aangeven welk van de SOLID principes geschonden zijn en hoe je dit kan oplossen

##### Praktisch, laptop (C#)

- Een oefening zoals de voorbeelden uit de cursus, waarbij een  refactoring dient gemaakt te worden op basis van één van de  SOLID-principes