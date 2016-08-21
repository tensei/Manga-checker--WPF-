﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using MangaChecker.Models;

namespace MangaChecker.Common {
    public static class GlobalVariables {
        public static readonly List<string> ViewerEnabled = new List<string> {"yomanga", "mangastream", "kireicake", "jaiminisbox" };

        public static ObservableCollection<MangaModel> NewMangasInternal =
            new ObservableCollection<MangaModel>();

        public static ObservableCollection<Image> ImagesInternal = new ObservableCollection<Image>();

        public static readonly Dictionary<string, string> SitesforDatabaseTables = new Dictionary<string, string> {
            {"Mangafox", "http://mangafox.me/"},
            {"Mangahere", "http://mangahere.co/"},
            {"Mangareader", "http://www.mangareader.net/"},
            {"Mangastream", "http://mangastream.com/"},
            {"Batoto", "http://bato.to/"},
            {"Webtoons", "http://www.webtoons.com/"},
            {"YoManga", "http://yomanga.co/"},
            {"Kissmanga", "http://kissmanga.com/"},
            {"Backlog", "/"},
            {"GoScanlation", "https://gameofscanlation.moe/"},
            {"KireiCake", "http://kireicake.com/" },
            {"Jaiminisbox", "https://jaiminisbox.com/" },
        };

        public static readonly List<string> DataGridFillSites = new List<string> {
            "Mangafox",
            "Mangahere",
            "Mangareader",
            "Mangastream",
            "Batoto",
            "Webtoons",
            "YoManga",
            "Kissmanga",
            "GoScanlation",
            "KireiCake",
            "Jaiminisbox"
        };

        private static readonly Dictionary<string, string> _listboxItemNames = new Dictionary<string, string> {
            {"All", null},
            {"Mangareader", null},
            {"Mangafox", null},
            {"Mangahere", null},
            {"Mangastream", null},
            {"Batoto", null},
            {"Kissmanga", null},
            {"Webtoons", null},
            {"Yomanga", null},
            {"GoScanlation", "GameOfScanlation"},
            {"KireiCake", null},
            {"Jaiminisbox", null},
            {"Backlog", null},
            {"DEBUG", null}
        };

        public static ObservableCollection<ListBoxItem> ListboxItemNames => createListboxItemNames();

        private static ObservableCollection<ListBoxItem> createListboxItemNames() {
            var obC = new ObservableCollection<ListBoxItem>();
            foreach (var listboxItemName in _listboxItemNames) {
                var x = new ListBoxItem {Content = listboxItemName.Key, ToolTip = listboxItemName.Value};
                obC.Add(x);
            }
            return obC;
        }
    }
}