Программа предназначена для проверки пользователей на знание регламента переговоров на железнодорожной станции.

Проверка происходит в рамках нескольких диалогов, состоящих из нескольких реплик. Диалоги и реплики задаются предварительно через панель администратора (или инсктруктора).

Взаимодействие с голосовым оператором происходит посредством речи. Программа также генерирует речь, имитируя сотрудника жд станции, с которым ведется диалог.

Для наглядности, диалог дублируется в виде чата, в котором также отображаются правильные и неправильные ответы.

Платформа: WPF
База данных: MS SQL
Паттерн разработки: MVVM
Переходы между страницами реализованы через Mediator
Взаимодействие с БД происходит через Entity Framework

Для работы приложения может понадобиться установить библиотеку VOSK, необходимую для распознавания речи.
Языковая модель уже находится в проекте. Если с ней возникнут проблемы, проверьте путь к ней в классе SpeechToText в поле modelPath

БД, в которой находились тестовые диалоги, уже удалена. Поэтому в репозиторий будет добавлено демонстрационное видео.
Также в репозиторий будет добавлен документ с диаграммами.


