


# Podcastner

Desktop app en C# con podcasts en variedad de idiomas para acquirir idiomas mendiante tecnicas de shadowing y reforzar listening. 
A futuro tendra su propia anki local para reestudiar las palabras nuevas que guardaste

## Contiene

- +100 Podcast
- Barra de busqueda conectada a TaddyAPI
- Guardado de podcast
- Dictionario de palabras desconocidas

## Tecnologias
- .NET (WPF)
- Taddy Podcast(API)
- C# (.NET)

  
##  Estructura del proyecto

```text
Podcastner/
│
├── Data/
│   ├── DataService.cs
│   
├── Models/
│   ├── Podcast.cs
│   ├── Episode.cs
│   ├── DictionaryResponse.cs
│   ├── Dictionary.cs
│   ├── Ankis.cs
│   ├── Episode.cs
│   ├── EpisodeResponse.cs
│   └── PodcastSearchResponse.cs
│
├── Pages/
│   ├── DictionaryWindow
│   ├── FavoritesWindow
│   ├── SaveWords
│   
├── Services/
│   ├── Episode.cs
│   ├── WhisperService.cs
│   ├── DictionaryService.cs
│   ├── SavedWords.cs
│   └── PodcastService.cs
│
├── Resources/
│   └── Audio/ (INACTIVA DEBIDO A LA API)
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
│
├── App.xaml
├── App.xaml.cs
│
└── Podcastner.csproj
```

## BETA
https://github.com/user-attachments/assets/acf7592d-a70e-479b-8f81-86b38b6bff78
