   M S B A M L   `   `   `  ����L  HLanguageHelper3.1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:LanguageHelper3._1.ControlsLanguageHelper3._1.Controls  5      5    /LanguageHelper3._1.Controls.AddTranslationPanel   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:LanguageHelper3._1.Controls     5      .��5	      � .+�5
   
   �� $��Choose a Japanese Word��6   $
��Left=�61   $��25��6L   $��	35,10,0,0q�6X   $	��Top=�6k   $	��165��6�   $��14(�6�   �� 5   
   -   5          ��Name$  
cbHiragana��5      $
��Left=�6'   $��25��6B   $��	40,40,0,0q�6N   $	��Top=�6a   $	��150��6y   $��13.333(�6�   �� 5   
   $��Kanji is ...��6   $
��Left=�6'   $��30��6B   $��	35,75,0,0q�6N   $	��Top=�6a   $��66��6y   $��14(�6�   	� 5   
   -   5         	�Name$ 
rbNewKanji��5      $	��New��6*   $
��Left=�68   $��15��6S   $��
28,110,0,0q�6_   $	��Top=�6s   $��50��6�   6�   	� 5   
   -   5        $ 
rbOldKanji��5      $��Existing��6*   $
��Left=�6=   $��15��6X   $��
78,110,0,0q�6d   $	��Top=�6x   $��65��6�   6�   	� 5   
   -   5        $ 	rbNoKanji��5      $
��None��6)   $
��Left=�68   $��15��6S   $��143,110,0,0q�6_   $	��Top=�6t   $��55��6�   6�   �� 5   
   -   5         ��Name$ tbKanji��5      $
��Left=�6#   $��20��6>   $��
40,130,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��150��6�   {�.  6�   �� 5   
   $��Enter English Word(s)��6   $
��Left=�60   $��28��6K   $��
35,155,0,0q�6W   $	��Top=�6k   $	��150��6�   $��14(�6�   �� 5   
   -   5        $ 	tbEnglish��5      $
��Left=�6%   $��20��6@   $��
40,188,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��150��6�   �� 5   
   -   5         ��Name$ 
lblSuccess��5      $(��"Translation(s) added successfully!��6$   $
��Left=�6Q   $��25��6l   $��
35,213,0,0q�6x   $	��Top=�6�   $	��165��6�   $��10.667(�6�   $y�Hidden=�6�   �� 5   
   -   5        $ lblError��5      $&�� Error - Translation(s) not added��6"   $
��Left=�6M   $��25��6h   $��
35,213,0,0q�6t   $	��Top=�6�   $	��165��6�   $��10.667(�6�   ���	#FFFF1D00$y�Hidden=�6�   �� 5   
   -	   5         ��Name$ btnAddTranslation��5      $��Add Translation(s)��6,   $
��Left=�6I   $��20��6d   $��
55,243,0,0q�6p   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -
   5        $  cbKanji��5      $
��Left=�6$   $��25��6?   $��
40,130,0,0q�6K   $	��Top=�6_   $	��150��6w   $��13.333(�6�   5      5      