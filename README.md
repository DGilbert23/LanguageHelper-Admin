# LanguageHelper-Admin
This WPF application is the administrative interface for entering Japanese <-> English translations. The intent of this projects (in conjunction with the LanguageHelper-Flashcard project) was to supplement other teaching methods, allowing a place for a "student" to record words they have learned/encountered and their translations, so that that data could be used to reinforce the knowledge at a later time.

This application implements the following functionality:

 - Login functionality that authenticates against data in the associated Azure hosted MSSQL Server database.
 - Add or remove English or Japanese words. This includes Japanese words in all three character styles; Hiragana, Katakana, and Kanji.
 - Add or remove relationships (i.e. Translations) between Englisha and Japanese words.
 - View the current data within the database in an easy to digest format.
