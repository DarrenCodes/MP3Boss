# MP3Boss
This application can load multiple mp3/m4a audio files via drag & drop, and display their tags (if any) inside editable textboxes. The user can then edit the tags as they see fit. 
The audio files' filenames can be formatted according to the tags of the file by choosing from a list of five formats. 
Changes can be made to all files or just one at a time. There is also a built in database which will return tag suggestions for the remaining empty tags when only a few tags are filled.

## Features
* Drag & Drop MP3/M4A or folders with audio files in it on the big white box and all acceptable files will be loaded.
* The tags of the audio file will be displayed in text boxes on the left hand side of the GUI, where editing can be performed.
* Changes can be applied to as many files as the user desires with one click of a button.
* The user can tick the checkboxes next to the relevant text boxes to "lock" the contents currently displayed for purposes such as applying that attribute to multiple files at once.
* The application will check all tags for any blank fields, and will prompt the user to make the necessary changes or to ignore & continue anyway. (Blank fields are discouraged as they might cause problems when formatting filenames.)
* As mentioned above, the program can format filenames. It will generate a filename using the tags of the file, which is why blank fields can cause problems. This feature is a great way of having all your audio files' filenames have the same format to help with readability.
* There are 5 formats available for the user to choose from when formatting filenames.
* The user can also remove any bits of text that the user might not want in their files' tags. Eg. You can search for "www" and replace it with nothing, so it will be removed. Entering replacement text will obviously also work. This, as well, can be applied to all files at once.
* The application also makes use of a SQLite database to store tags. SO if the user wants to search for songs that "Michael Jackson" made, if it's in the database, by typing "Michael Jackson" in the "Album Artist" or "Contributing Artist" text boxes and clicking on "Suggest", the remaining fields will be populated with suggestions that the user can select from.
* The program can load any selected SQLite database that follows the same schema that I designed.


### Displayed Tags are:
* Song Title
* Album Artist
* Contributing Artist(s)
* Album
* Year
* Track no.
* Genre


#### Into the future ->
I plan on adding features pertaining to the database part of this application, such as adding new entries to the database via the GUI. As well as loading different SQLite databases, which will allow users to use preloaded databases from other users.
