using ClassicalMusic.Models;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalMusic.Services
{
    public class PlayerService
    {
        public IMediaManager mediaPlayer;
        public PlayerService()
        {
            mediaPlayer = CrossMediaManager.Current;
        }

        public void PlayRadio(string radioName, string link)
        {
            ClearQueue();
            var media = new MediaFile()
            {
                Availability = ResourceAvailability.Remote,
                Type = MediaFileType.Audio,
                Url = link,
                Metadata = new MediaFileMetadata()
                {
                    DisplayTitle = radioName,
                    Title = radioName,
                    MediaUri = link
                }
            };
            mediaPlayer.MediaQueue.Add(media);
            Play();
        }
        public void PlayOpera(Composer composer, Opera opera)
        {
            PlayOperaFromIndex(composer, opera, 0);
        }
        public void PlayOperaFromIndex(Composer composer, Opera opera, int index)
        {
            ClearQueue();
            EnqueueOperaFromIndex(composer, opera, index);
            Play();
        }
        public void EnqueueOpera(Composer composer, Opera opera)
        {
            EnqueueOperaFromIndex(composer, opera, 0);
        }
        public void EnqueueOperaFromIndex(Composer composer, Opera opera, int index)
        {
            for (int i = index; i < opera.Tracks.Count; i++)
            {
                var track = opera.Tracks[i];
                var media = new MediaFile()
                {
                    Availability = track.Link.StartsWith("http") ? ResourceAvailability.Remote : ResourceAvailability.Local,
                    Metadata = new MediaFileMetadata()
                    {
                        Album = opera.Name,
                        AlbumArtist = composer.Name,
                        Artist = composer.Name,
                        Composer = composer.Name,
                        Genre = "Classical Music",
                        NumTracks = opera.Tracks.Count,
                        Title = track.Title,
                        TrackNumber = i + 1,
                        Author = composer.Name,
                        MediaUri = track.Link,
                        DisplayTitle = track.Title
                    },
                    Type = MediaFileType.Audio,
                    Url = track.Link
                };
                mediaPlayer.MediaQueue.Add(media);
            }
        }
        public void ClearQueue()
        {
            Stop();
            mediaPlayer.MediaQueue.Clear();
        }
        public void Play()
        {
            mediaPlayer.PlaybackController.Play();
        }
        public void Pause()
        {
            mediaPlayer.PlaybackController.Pause();
        }
        public void Stop()
        {
            mediaPlayer.PlaybackController.Stop();
        }
        public void Next()
        {
            mediaPlayer.PlaybackController.PlayNext();
        }
        public void Previous()
        {
            mediaPlayer.PlaybackController.PlayPreviousOrSeekToStart();
        }
    }
}
