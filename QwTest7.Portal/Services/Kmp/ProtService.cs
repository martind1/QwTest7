﻿using Microsoft.AspNetCore.Components;
using QwTest7.Portal.Services.Kmp.Helper;
using Radzen.Blazor;
using Serilog;
using System.Text.Json;

namespace QwTest7.Portal.Services.Kmp
{
    /// <summary>
    /// Eintrag für Statusliste
    /// </summary>
    public class StatusListEntry
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }

    /// <summary>
    /// Service für Protokollierung und Statusmeldung
    /// </summary>
    public class ProtService : ComponentBase
    {
        #region Statustext, Eventconsole
        public string StatusText { get; set; } = "Statustext";
        public event Action OnStatusTextChange;
        private void StatusTextChanged() => OnStatusTextChange?.Invoke();

        public IList<StatusListEntry> StatusListEntries { get; set; } = new List<StatusListEntry>();
        public event Action<StatusListEntry> OnStatusListAdd;
        private void StatusListAdded(StatusListEntry statusListEntry) => OnStatusListAdd?.Invoke(statusListEntry);


        public void ProtX(ProtFlags flags, string Text)
        {
            if ((flags & ProtFlags.SMess) != 0)
            {
                StatusText = Text;
                //Ereignis zum Anzeigen woanders auslösen:
                StatusTextChanged();
            }
            if ((flags & ProtFlags.List) != 0)
            {
                var statusListEntry = new StatusListEntry() { Date = DateTime.Now, Text = Text };
                StatusListEntries.Insert(0, statusListEntry);  //am Anfang einfügen
                while (StatusListEntries.Count > AppParameter.MaxStatusListEntries)  //1000
                {
                    //Größe Beschränken
                    StatusListEntries.RemoveAt(StatusListEntries.Count - 1);
                }
                StatusListAdded(statusListEntry);
            }
            if ((flags & ProtFlags.File) != 0)
            {
                if ((flags & ProtFlags.Debug) != 0)
                    Log.Debug(Text);
                else
                    Log.Information(Text);
            }
        }

        /// <summary>
        /// Logfile Information
        /// </summary>
        public void Prot0(string Text)
        {
            ProtX(ProtFlags.File, Text);
        }

        /// <summary>
        /// Logfile + Statuszeile + Liste
        /// </summary>
        public void Prot0SL(string Text)
        {
            ProtX(ProtFlags.File | ProtFlags.SMess | ProtFlags.List, Text);
        }

        /// <summary>
        /// Statuszeile
        /// </summary>
        public void SMess(string Text)
        {
            ProtX(ProtFlags.SMess, Text);
        }

        /// <summary>
        /// Statuszeile mit Object->JSON
        /// </summary>
        public void SMess(object value)
        {
            SMess(JsonSerializer.Serialize(value));
        }

        /// <summary>
        /// Statuszeile und Protlist
        /// </summary>
        public void SMessL(string Text)
        {
            ProtX(ProtFlags.SMess | ProtFlags.List, Text);
        }

        //Logfile und Statuszeile

        public void Debug0()
        {
            //macht nix. Nur für Breakpoint
        }

        #endregion

    }

    [Flags]
    public enum ProtFlags
    {
        SMess = 1,
        List = 2,
        File = 4,
        Database = 8,
        WarnDlg = 16,
        ErrDlg = 32,
        TimeStamp = 64,
        Debug = 128
    }
    /*
       TProtModus = (prTrm,    {Ausgabe in ListBox}
                prFile,        {Ausgabe in Protokolldatei}
                prRemain,      {Zeilenwechsel in Listbox unterdrücken}
                prTimeStamp,   {mit Protokolierung von Timestamp}
                prMsg,         {Ausgabe als Dialogbox}
                prList,        {Ausgabe in Listbox}
                prDatabase,    {Ausgabe in DB Tabelle}
                prWarn,        {i.V.m. prMsg: 'Warnung'   (WMess: 'Information'}
                prErr,         {i.V.m. WMessErr: 'Error'}
                prSMess,       {Ausgabe in Statuszeile}
                prNoLbStamp,   {In Listbox kein Timestamp, PC Nr}
                prNoLbFocus);  {In Listbox auch bei Focus auffüllen}

     */
}