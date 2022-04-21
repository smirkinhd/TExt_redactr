using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bl2
{
    public static class TextWork
    {
        // Метод поиска текста в TextBox
        // Для использования создаем в форме поиска глобальную переменную 
        // типа int = 0 для стартовой позиции поиска,
        // передаем в метод ссылки на TextBox'ы с исходным и искомым текстами,
        // а также необходимо указать, учитывать ли регистр букв при поиске (True - учитывать, False - не учитывать)
        public static int FindTextBox(ref RichTextBox textBox, string findText, ref int findCutLength)
        {
            // Поиск с учетом регистра
                if (textBox.Text.Contains(findText))
                {
                    // Заносим текст в переменную string, удаляем из него уже пройденный 
                    // текст (findCutLength) в переменной nextText
                    string text = textBox.Text;
                    string nextText = text.Remove(0, findCutLength);
                    // Ищем в nextText
                    int resultPosition = nextText.IndexOf(findText);
                    // Если искомое выражение найдено - выделяем его, добавляем его позицию и длину 
                    // к значению пройденного текста (findCutLenght)
                    if (resultPosition != -1)
                    {
                        textBox.Select(resultPosition + findCutLength, findText.Length);
                        textBox.ScrollToCaret();
                        textBox.Focus();
                        findCutLength += findText.Length + resultPosition;
                    }
                    // Если попытка поиска не первая, и больше совпадений в тексте нет - обнуляем
                    // значение пройденного текста и начинаем поиск сначала
                    else if (resultPosition == -1 && findCutLength != 0)
                    {
                        findCutLength = 0;
                        return FindTextBox(ref textBox, findText, ref findCutLength);
                    }
                }
                else
                {
                    findCutLength = 0;
                    MessageBox.Show("По вашему запросу ничего не нашлось.", "Совпадений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            return 0;
        }

        // Метод "Заменить"
        public static int ReplaceTextBox(ref RichTextBox textBox, string findText, string replaceText, ref int findCutLength)
        {
                if (textBox.Text.Contains(findText))
                {
                    if (textBox.SelectedText == "" || textBox.SelectedText != findText)
                    {
                        string text = textBox.Text;
                        string nextText = text.Remove(0, findCutLength);
                        int resultPosition = nextText.IndexOf(findText);
                        if (resultPosition != -1)
                        {
                            textBox.Select(resultPosition + findCutLength, findText.Length);
                            textBox.ScrollToCaret();
                            textBox.Focus();
                            findCutLength += findText.Length + resultPosition;
                        }
                        else if (resultPosition == -1 && findCutLength != 0)
                        {
                            findCutLength = 0;
                            return ReplaceTextBox(ref textBox, findText, replaceText, ref findCutLength);
                        }
                    }
                    else if (textBox.SelectedText == findText)
                    {
                        textBox.SelectedText = replaceText;
                    }
                }
                else
                {
                    findCutLength = 0;
                    MessageBox.Show("По вашему запросу ничего не нашлось.", "Совпадений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            return 0;
        }

        // Метод "Заменить всё"
        public static int ReplaceAllTextBox(ref RichTextBox textBox, string findText, string replaceText)
        {
            string text = textBox.Text;
            string words = findText;
            if (textBox.Text.Contains(words))
            {
                int startPosition = text.IndexOf(words);
                textBox.Select(startPosition, words.Length);
                textBox.SelectedText = replaceText;
                return ReplaceAllTextBox(ref textBox, findText, replaceText);
            }
            else
            {
                MessageBox.Show("Замены произведены успешно.", "Заменить всё", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return 0;
        }

    }
}