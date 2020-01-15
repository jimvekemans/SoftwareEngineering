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

<<<<<<< HEAD
<u>View <a href="./Branching.md">Branching.md</a> for a complete explanation of local vs remote branches</u>

Branches are used to create (slightly) altered / newer / better versions of the codebase. **<u>Using branches makes sure that there is a safe space to work on unstable code</u>.** Usually you would create a new branch for every new feature that gets added. The `master`-branch gets created automatically and should be used for code that is ready for production. Oftentimes, the master-branch is updated when the new version of the `develop`-branch is deemed good enough to be considered as a MVP (Minimal Viable Product). When the code of a branch is finished, it gets **<u>merged</u>** into a branch that contains a more complete version of the codebase. A merge combines two branches into one by comparing the commits of each branch. Every new / modified file of branch 1 gets compared to the same file on branch 2. If the file is only on 1 of 2 branches, then it gets merged automatically. Whenever the file is on both branches and both branches have modified the file, then the modified content is compared. When the file is modified in other places, the code is usually merged without issue BUT when there is a different version of some code, then it is up to a **reviewer** to check which version should be kept for the merged result.
=======
[Local vs remote branching explained]: Branches.md
- View <a href="./Branching.md" text="Branching.md"/> for a complete explanation of branching (local and remote)s
>>>>>>> 7fc73505fe1292bc243282283d5181f270081ce8

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

### Wat moet je kennen en kunnen? 

SOLID kan aan bod komen zowel in het schriftelijk (gesloten boek) als in het praktische gedeelte (open boek).

##### Schriftelijk, gesloten boek

- De SOLID principes kunnen opsommen en kort beschrijven
- Op basis van gedrukte broncode op papier aangeven welk van de SOLID principes geschonden zijn en hoe je dit kan oplossen

##### Praktisch, laptop (C#)

- Een oefening zoals de voorbeelden uit de cursus, waarbij een  refactoring dient gemaakt te worden op basis van één van de  SOLID-principes