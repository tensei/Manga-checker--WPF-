﻿using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Input;
using MangaChecker.Common;
using MangaChecker.Database;
using MangaChecker.Models;
using MangaChecker.Sites;
using MangaChecker.Sites.RSS;
using PropertyChanged;

namespace MangaChecker.ViewModels {
    [ImplementPropertyChanged]
    public class SettingViewModel {
        public SettingViewModel() {
            if (File.Exists("MangaDB.sqlite")) {
                SetupSettingsPanel();
            }
            SaveCommand = new ActionCommand(SaveBtn_Click);
            MangastreamCommand = new ActionCommand(MangastreamOnOffBtn_Click);
            MangareaderCommand = new ActionCommand(MangareaderOnOffBtn_Click);
            MangafoxCommand = new ActionCommand(MangafoxOnOffBtn_Click);
            MangahereCommand = new ActionCommand(MangahereOnOffBtn_Click);
            BatotoCommand = new ActionCommand(BatotoOnOffBtn_Click);
            KissmangaCommand = new ActionCommand(KissmangaOnOffBtn_Click);
            WebtoonsCommand = new ActionCommand(WebtoonsOnOffBtn_Click);
            YomangaCommand = new ActionCommand(YomangaOnOffBtn_Click);
            LinkOpenCommand = new ActionCommand(LinkOpenBtn_Click);
            UpdateBatotoCommand = new ActionCommand(UpdateBatotoBtn_Click);
            GameOfScanlationCommand = new ActionCommand(GameOfScanlationOnOffBtn_Click);
            KireiCakeCommand = new ActionCommand(KireiCakeOnOffBtn_Click);
            JaiminisboxCommand = new ActionCommand(JaiminisboxOnOffBtn_Click);
        }

        public string Timebox { get; set; }

        public string BatotoRss { get; set; }

        public bool MangastreamOnOff { get; set; }

        public bool MangareaderOnOff { get; set; }

        public bool MangafoxOnOff { get; set; }


        public bool MangahereOnOff { get; set; }

        public bool BatotoOnOff { get; set; }

        public bool KissmangaOnOff { get; set; }

        public bool WebtoonsOnOff { get; set; }

        public bool YomangaOnOff { get; set; }

        public bool LinkOpen { get; set; }

        public bool GameOfScanlationOnOff { get; set; }
        public bool KireiCakeOnOff { get; set; }
        public bool JaiminisboxOnOff { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand MangastreamCommand { get; }
        public ICommand MangareaderCommand { get; }
        public ICommand MangafoxCommand { get; }
        public ICommand MangahereCommand { get; }
        public ICommand BatotoCommand { get; }
        public ICommand KissmangaCommand { get; }
        public ICommand WebtoonsCommand { get; }
        public ICommand YomangaCommand { get; }
        public ICommand GameOfScanlationCommand { get; }
        public ICommand KireiCakeCommand { get; }
        public ICommand JaiminisboxCommand { get; }
        public ICommand LinkOpenCommand { get; }
        public ICommand UpdateBatotoCommand { get; }
        public ICommand ImportCommand { get; }
        public ICommand ExportCommand { get; }


        private void SetupSettingsPanel() {
            var settings = Sqlite.GetSettings();
            Timebox = settings["refresh time"];
            BatotoRss = settings["batoto_rss"];

            if (settings["mangastream"] == "1") {
                MangastreamOnOff = true;
            }
            if (settings["mangareader"] == "1") {
                MangareaderOnOff = true;
            }
            if (settings["mangafox"] == "1") {
                MangafoxOnOff = true;
            }
            if (settings["mangahere"] == "1") {
                MangahereOnOff = true;
            }
            if (settings["batoto"] == "1") {
                BatotoOnOff = true;
            }
            if (settings["kissmanga"] == "1") {
                KissmangaOnOff = true;
            }
            if (settings["webtoons"] == "1") {
                WebtoonsOnOff = true;
            }
            if (settings["kireicake"] == "1") {
                KireiCakeOnOff = true;
            }
            if (settings["jaiminisbox"] == "1") {
                JaiminisboxOnOff = true;
            }
            if (settings["yomanga"] == "1") {
                YomangaOnOff = true;
            }
            if (settings["goscanlation"] == "1") {
                GameOfScanlationOnOff = true;
            }
            if (settings["open links"] == "1") {
                LinkOpen = true;
            }
        }


        private void SaveBtn_Click() {
            Sqlite.UpdateSetting("refresh time", Timebox);
            Sqlite.UpdateSetting("batoto_rss", BatotoRss);
        }

        private void MangastreamOnOffBtn_Click() {
            if (!Equals(MangastreamOnOff, false)) {
                Sqlite.UpdateSetting("mangastream", "1");
            } else {
                Sqlite.UpdateSetting("mangastream", "0");
            }
        }

        private void MangareaderOnOffBtn_Click() {
            if (!Equals(MangareaderOnOff, false)) {
                Sqlite.UpdateSetting("mangareader", "1");
            } else {
                Sqlite.UpdateSetting("mangareader", "0");
            }
        }

        private void MangafoxOnOffBtn_Click() {
            if (!Equals(MangafoxOnOff, false)) {
                Sqlite.UpdateSetting("mangafox", "1");
            } else {
                Sqlite.UpdateSetting("mangafox", "0");
            }
        }

        private void MangahereOnOffBtn_Click() {
            if (!Equals(MangahereOnOff, false)) {
                Sqlite.UpdateSetting("mangahere", "1");
            } else {
                Sqlite.UpdateSetting("mangahere", "0");
            }
        }

        private void KissmangaOnOffBtn_Click() {
            if (!Equals(KissmangaOnOff, false)) {
                Sqlite.UpdateSetting("kissmanga", "1");
            } else {
                Sqlite.UpdateSetting("kissmanga", "0");
            }
        }

        private void BatotoOnOffBtn_Click() {
            if (!Equals(BatotoOnOff, false)) {
                Sqlite.UpdateSetting("batoto", "1");
            } else {
                Sqlite.UpdateSetting("batoto", "0");
            }
        }

        private void LinkOpenBtn_Click() {
            if (!Equals(LinkOpen, false)) {
                Sqlite.UpdateSetting("open links", "1");
            } else {
                Sqlite.UpdateSetting("open links", "0");
            }
        }

        private void WebtoonsOnOffBtn_Click() {
            if (!Equals(WebtoonsOnOff, false)) {
                Sqlite.UpdateSetting("webtoons", "1");
            } else {
                Sqlite.UpdateSetting("webtoons", "0");
            }
        }

        private void YomangaOnOffBtn_Click() {
            if (!Equals(YomangaOnOff, false)) {
                Sqlite.UpdateSetting("yomanga", "1");
            } else {
                Sqlite.UpdateSetting("yomanga", "0");
            }
        }

        private void GameOfScanlationOnOffBtn_Click() {
            if (!Equals(GameOfScanlationOnOff, false)) {
                Sqlite.UpdateSetting("goscanlation", "1");
            } else {
                Sqlite.UpdateSetting("goscanlation", "0");
            }
        }
        private void KireiCakeOnOffBtn_Click() {
            if (!Equals(KireiCakeOnOff, false)) {
                Sqlite.UpdateSetting("kireicake", "1");
            } else {
                Sqlite.UpdateSetting("kireicake", "0");
            }
        }

        private void JaiminisboxOnOffBtn_Click() {
            if (!Equals(JaiminisboxOnOff, false)) {
                Sqlite.UpdateSetting("jaiminisbox", "1");
            } else {
                Sqlite.UpdateSetting("jaiminisbox", "0");
            }
        }

        private void UpdateBatotoBtn_Click() {
            new Thread(new ThreadStart(delegate {
                var rssList = Batoto.Get_feed_titles();
                var jsMangaList = Sqlite.GetMangaNameList("batoto");
                foreach (var rssManga in rssList) {
                    var name =
                        rssManga[0].ToString().Split(new[] {" - "}, StringSplitOptions.RemoveEmptyEntries)[0];
                    if (!jsMangaList.Contains(name)) {
                        jsMangaList.Add(name);
                        var manga = new MangaModel {
                            Site = "batoto",
                            Name = name,
                            Chapter = (string) rssManga[1],
                            Date = (DateTime) rssManga[3],
                            RssLink = (string) rssManga[2]
                        };
                        Sqlite.AddManga(manga);
                        DebugText.Write($"[Batoto] added {(string) rssManga[0]}");
                    }
                }
            })).Start();
        }

        public static string Base64Encode(string plainText) {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData) {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}