## Zelt Language Syntax Documentation

### Introduction

Zelt provides a unique approach to programming with a consistent syntax pattern across types and instances. In Zelt, every statement follows the pattern: `identifier : type = expression;`.

### Data Types

#### **Primitives**

- **Integers**: Denoted by the keyword `Int`.

  ```zelt
  myInteger : Int = 5;
  ```

- **Strings**: Denoted by the keyword `String`.

  ```zelt
  greeting : String = "Hello, Zelt!";
  ```

- **Floating Points**: Denoted by the keyword `Float`.

  ```zelt
  piValue : Float = 3.14159;
  ```

#### **Lists**

Lists are represented using square brackets `[]` around the type of the elements.

```zelt
myList : [String] = ["apple", "banana", "cherry"];
```

#### **Dictionaries**

Dictionaries use curly braces `{}` with two types: key and value.

```zelt
myDict : {String, Int} = dict { ("apple", 1), ("banana", 2) };
```

### **Functions**

Functions in Zelt can be thought of as mappings between types. They have inputs, represented in parentheses `()`, and return types, represented after the arrow `=>`.

```zelt
sumFunction : (Int, Int) => Int = (a : Int, b : Int) => Int { return a + b; };
```

The `caller` keyword inside a function provides a reference to the entity calling the function, akin to `this` in many OOP languages.

### **Structs**

Structs are custom data structures defined by users.

**Definition Syntax**:
```zelt
Vector2 : Struct(Float, Float) = struct { x : Float; y : Float };
```

**Instantiation**:
```zelt
myVector : Vector2 = Vector2(5.0, 6.0);
```

### **Interfaces**

Interfaces in Zelt allow for abstract type definitions. Types implementing an interface must provide definitions for all members of the interface.

```zelt
INormalize : Interface( (Vector2) => Vector2 ) = interface { normalize : (Vector2) => Vector2; };
```

### **Generics**

Single uppercase letters, like `T`, are reserved for representing generic types.

```zelt
ITriple : Interface( T () => T ) = interface { triple : T () => T };
```

### Explicit Interface Implementations

Structs can explicitly implement interfaces by stating the interface name using the `implements` keyword.

```zelt
MyIntStruct : Struct(Int) = struct implements ITriple { value : Int; };
```
