# Old-Phone-Keypad
This project simulates an old phone keypad functionality, where users can input text using a numerical keypad system. The implementation includes features like key mapping, handling special keys (#, *, 0), and validating user input.

---

## Features

- **Key Mapping**: Maps numerical keys to their corresponding letters or symbols.
- **Special Key Support**:
  - `#` (Send Key): Ends the input sequence.
  - `*` (Delete Key): Deletes the last entered character.
  - `0` (Space Key): Adds a space to the result.
- **Validation**:
  - Ensures input ends with the `SendKey`.
  - Rejects invalid keys not present on the keypad.
- **Dynamic Character Mapping**: Supports looping through characters based on the number of key presses.

---

## How to Use

### Console Version
1. Start the application.
2. Input text using the simulated phone keypad
### Unity UI Version
1. Run PhonePad Application
2. Interact with the on-screen keypad using your mouse or touch input.
3. Press buttons to simulate key presses and see the corresponding text in real-time.
4. The # will clear the text

---
Here's the section for the `README.md` explaining the relationships between the classes, project scaling, and design considerations:

---

## Class Relationships

- **`PhonePad` (Base Class)**:  
  The core implementation for managing phone keypad functionality. This class provides fundamental methods such as input handling and character mapping, designed for extension and reuse.
  - Other keypad types (e.g., custom layouts or multilingual support) can inherit from `PhonePad` to implement their specific logic while reusing existing functionality.

- **`OldPhonePad`**:  
  A concrete implementation of the `PhonePad` class designed to parse input from external sources, utilizing the `OldPhoneKeypad` to manage the mapping of keys and characters. This class handles the logic for interpreting the user input, including character selection based on key presses. It also provides utility functions, such as `GetPhoneKey`, which returns the specific phone key at a given row and column, and `GetCodesByKey`, which retrieves the associated character mappings for a key. These functions enable easy integration with any UI framework, allowing for dynamic display and interaction with the keypad.
 
- **`OldPhoneKeypad`**:  
  A information of the `OldPhonePad` class, specifically simulating old phone keypads with predefined mappings.  
  - Developers can modify or extend the `keycodes` array in this class to support additional characters, symbols, or special inputs.

- **Unity UI Integration**:  
  The Unity UI version interacts with the core logic through a controller script (`KeypadController` and `KeyButton`), ensuring that UI and logic are decoupled. This design allows for seamless scaling or swapping of UI frameworks without affecting the core functionality.

---

## Project Scaling and Extensibility

1. **Adding New Keypad Types**:  
   Create a new class inheriting from `PhonePad`. Override necessary methods to define custom behavior or mappings for the new keypad type. This modular design supports diverse keypad styles, such as predictive text or emoji input.

2. **Adding New Characters**:  
   To expand the range of characters or symbols:
   - Open the `OldPhoneKeypad` class.
   - Update the `keycodes` array with the desired characters.

3. **Multilingual Support**:  
   - Implement support for multiple languages by creating new character mappings for each language.
   - Add a language selection feature, allowing users to dynamically switch between mappings during runtime.

---

Here's a suggested structure description for your README:

---

## Repository Structure

C# Console
    - Contains the C# console application logic for parsing and handling input where you can test and execute the logic.

Exe by Unity
  - Exe folder : Contains the compiled executable files for running the project outside of Unity.
  - Source folder : Contains the C# source code specifically developed for the Unity-based UI version of the project, handling keypads, characters, and input parsing logic.

