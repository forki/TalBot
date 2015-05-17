﻿namespace TalBot.PluginsFSharp

open System.IO
open TalBot
open System.Collections.Generic

type FolderMonitorSample() =
    interface IPlugin with
        member x.Run(): IEnumerable<Message> =    
            new DirectoryInfo(@"C:\Test")
            |> (fun x -> x.GetDirectories(""))
            |> Seq.sortBy (fun x -> -x.CreationTime.Ticks)
            |> Seq.map (fun x -> 
                    { 
                        Message.destination = "SlackBot";
                        sender = "FolderMonitor";
                        text = "Folder " + x.Name + " has been added to the test folder as of " + x.CreationTime.ToString("f") + ".";
                        icon = "" 
                    })

type SampleFSharpPlugin() =
    interface IPlugin with
        member x.Run(): IEnumerable<Message> =    
            [|{
                Message.destination = "SlackBot";
                sender = "SamplePluginFSharp";
                text="Hello from FSharp plug-in";
                icon = ""
            }|] :> seq<Message>