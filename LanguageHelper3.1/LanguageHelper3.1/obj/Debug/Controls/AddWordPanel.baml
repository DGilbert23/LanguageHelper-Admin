   M S B A M L   `   `   `  ����L  HLanguageHelper3.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:LanguageHelper3._1.ControlsLanguageHelper3._1.Controls  5      .    (LanguageHelper3._1.Controls.AddWordPanel   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:LanguageHelper3._1.Controls     5      .��5	      � .+�5
   
   �� $
��Left=�6   $	��350��60   $	��Top=�6=   $	��230��6U   .+�5      �� $��Hiragana��6   $
��Left=�6'   $��30��6B   $��10,0,0,0q�6N   $��85��6`   $��14(�6k   �� 5      -   5          ��Name$  
tbHiragana��5      $
��Left=�6*   $��25��6E   $��10,0,0,0q�6Q    �� TextWrapping$
 Wrap=�6c   $	��210��6w   $��13.333(�6�    J� IsManipulationEnabled . 6�   �� 5      $��Kanji (optional)��6   $
��Left=�6/   $��30��6J   $��10,0,0,0q�6V   $	��150��6h   $��14(�6t   �� 5      -   5        $  tbKanji��5      $
��Left=�6'   $��25��6B   $��10,0,0,0q�6N   $
 Wrap=�6`   $	��210��6t   $��13.333(�6�   �� 5      $��Romanji��6   $
��Left=�6&   $��30��6A   $��10,0,0,0q�6M   $��85��6_   $��14.667(�6j   �� 5      -   5        $  	tbRomanji��5      $
��Left=�6)   $��25��6D   $��10,0,0,0q�6P   $
 Wrap=�6b   $	��210��6v   $��13.333(�6�   �� 5      $$��English Translation (optional)��6   $
��Left=�6=   $��30��6X   $��10,0,0,0q�6d   $	��210��6v   $��14.667(�6�   �� 5      -   5        $  	tbEnglish��5      $
��Left=�6)   $��25��6D   $��10,0,0,0q�6P   $
 Wrap=�6b   $	��210��6v   $��13.333(�6�   �� 5      -   5         ��Name$ 
lblSuccess��5      $��Word added succesfully!��6(   $��Center=�6J   $y�	Collapsed=�6g   �� 5      -   5        $ lblError��5      $-��'An error occurred.  Word was not added.��6&   $��Center=�6X   $y�Hidden=�6u   ���	#FFFF28006�   �� 5      -   5         ��Name$ buttonAddWord��5      $��Add Word��6,   $
��Left=�6?   $��20��6Z   $��40,0,0,0q�6f   $	��150��6x   6�   5      5      5      