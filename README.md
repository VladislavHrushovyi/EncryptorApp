﻿# SUMMARY

### Requirements:
1. Application should be designed in a layer architecture style.
2. All business logic is covered by unit tests
3. Each encryption should be saved to history log. Show history log must be fast operation and stored in-memory, but it also should be propagated between each new application launch.
4. All application-required properties are loaded from `application.properties` file and inserted in annotated fields.

### Use Case:
A user starts an application and sees a console menu. They can:
1. Encrypt a message using one of the provided encryption algorithms.
2. Display the history of all provided and encrypted messages:
```
{DateTime} - Message '{originalMessage}' was encrypted via {algorithm} into '{encryptionResult}'
```
3. History can be shown to the user by specific date (Based on history logs. If no logs for specific date, than it cannot be selected from the menu)
4. History can show count of usage of all algorithms grouped by it’s type.
   ```
   {AlgorithmA} was used 5 times
   {AlgorithmB} was used 3 times
   ```
5. History can show unique encryptions based on message and algorithm.
   ```
   Message '{originalMessage}' was encrypted via {algorithm} 5 times
   ```

### Technical details:
At the beginning of the program, the system should read application.properties. Then, it should identify fields annotated with @Injectable. For instance:
```
[Injactable("some.properties")]
private String/int/long/double/float fieldValue;
```
`application.properties`  is stored in resources directory and contains a list of all application-required properties.
If no property is found, the application startup should fail.
**The Caesar key should be inserted via this property.**
