# CrewRed_test_task

Answers

9. Assume your program will be used on much larger data files. Describe in a few sentences what you would change if you knew it would be used for a 10GB CSV input file.
First, I'd read csv file by rows. Put a 10GB file into memory is not the best idea. Then, I'd use the special library for adding big amount of data (EFCore.BulkExtensions). And the last? I'd use async operations where I can.

Number of rows in your table after running the program. In DB I have 29889 rows.
