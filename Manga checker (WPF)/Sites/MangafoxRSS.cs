﻿using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Manga_checker.Database;
using Manga_checker.Handlers;
using Manga_checker.ViewModels;

namespace Manga_checker.Sites {
    internal class MangafoxRSS {
        //public MainWindow Main;
        public static void Get_feed_titles(string url, MangaViewModel manga) {
            var ch_plus = int.Parse(manga.Chapter);
            ch_plus++;
            var feed = RSSReader.Read(url);
            if (feed == null) return;
            foreach (var mangs in feed.Items) {
                //ParseFile.setManga("mangafox", name, chapter);
                if (mangs.Title.Text.ToLower().Contains(ch_plus.ToString().ToLower())) {
                    if (ParseFile.GetValueSettings("open links") == "1") {
                        Process.Start(mangs.Links[0].Uri.AbsoluteUri);
                        ParseFile.SetManga("mangafox", manga.Name, ch_plus.ToString());
                        Sqlite.UpdateManga("mangafox", manga.Name, ch_plus.ToString(), mangs.Links[0].Uri.AbsoluteUri);
                    }

                    manga.Chapter = ch_plus.ToString();
                    DebugText.Write($"[Mangafox] {manga.Name} {ch_plus} Found new Chapter");
                }
            }
        }

        public static void Check(MangaViewModel manga) {
            var name = Regex.Replace(manga.Name, "[^0-9a-zA-Z]+", "_").Trim('_').ToLower();
            //DebugText.Write(Regex.Replace("tes__ygr___rhut_","[^0-9a-zA-Z]+","_").Trim('_')); //test regex output
            try {
                Get_feed_titles("http://mangafox.me/rss/" + name + ".xml",
                    manga);
            }
            catch (Exception e) {
                //Main.DebugTextBox.Text += string.Format("[Mangafox] Error {0} {1}", manga, e);
                DebugText.Write($"[Mangafox] Error {manga.Name} {e.Message} {name}.");
            }
        }
    }
}