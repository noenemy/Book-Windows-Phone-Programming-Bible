using System;
using Microsoft.Phone.BackgroundAudio;
using System.Collections.Generic;

namespace AudioPlayAgent
{
    public class AudioPlayer : AudioPlayerAgent
    {
        // 플레이 리스트에서 현재 트랙의 인덱스
        static int nCurrentIndex = 0;

        // 플레이 리스트 구성하기
        private static List<AudioTrack> _playlist = new List<AudioTrack>
        {
            new AudioTrack(new Uri("Kalimba.mp3", UriKind.Relative),
                    "Kalimba",
                    "Mr. Scruff",
                    "Ninja Tuna",
                    null),
            new AudioTrack(new Uri("Maid with the Flaxen Hair.mp3", UriKind.Relative),
                    "Maid with the Flaxen Hair",
                    "Richard Stoltzman",
                    "Fine Music, Vol. 1",
                    null),
            new AudioTrack(new Uri("Sleep Away.mp3", UriKind.Relative),
                    "Sleep Away",
                    "Bob Acri",
                    "Bob Acri",
                    null)
        };

        /// <summary>
        /// Called when the playstate changes, except for the Error state (see OnError)
        /// </summary>
        /// <param name="player">The BackgroundAudioPlayer</param>
        /// <param name="track">The track playing at the time the playstate changed</param>
        /// <param name="playState">The new playstate of the player</param>
        /// <remarks>
        /// Play State changes cannot be cancelled. They are raised even if the application
        /// caused the state change itself, assuming the application has opted-in to the callback
        /// </remarks>
        protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
        {
            // 플레이어 상태 변화에 대한 처리
            switch (playState)
            {
                // 트랙이 준비되면 재생을 시작한다.
                case PlayState.TrackReady:
                    player.Play();
                    break;
                // 트랙 재생이 완료되었으면 다음 트랙으로 이동한다.
                case PlayState.TrackEnded:
                    nCurrentIndex++;
                    if (nCurrentIndex >= _playlist.Count)
                        nCurrentIndex = 0;
                    player.Track = _playlist[nCurrentIndex];
                    break;

            }

            NotifyComplete();
        }


        /// <summary>
        /// Called when the user requests an action using system-provided UI and the application has requesed
        /// notifications of the action
        /// </summary>
        /// <param name="player">The BackgroundAudioPlayer</param>
        /// <param name="track">The track playing at the time of the user action</param>
        /// <param name="action">The action the user has requested</param>
        /// <param name="param">The data associated with the requested action.
        /// In the current version this parameter is only for use with the Seek action,
        /// to indicate the requested position of an audio track</param>
        /// <remarks>
        /// User actions do not automatically make any changes in system state; the agent is responsible
        /// for carrying out the user actions if they are supported
        /// </remarks>
        protected override void OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
        {
            // 사용자 요청에 대해 처리한다.
            switch (action)
            {
                // 재생할 트랙을 지정하고 재생한다.
                case UserAction.Play:
                    if (player.Track == null)
                        player.Track = _playlist[nCurrentIndex];
                    player.Play();
                    break;
                // 현재 트랙의 재생을 일시정지한다.
                case UserAction.Pause:
                    player.Pause();
                    break;
                // 이전 트랙으로 이동한다.
                case UserAction.SkipPrevious:
                    nCurrentIndex--;
                    if (nCurrentIndex < 0)
                        nCurrentIndex = _playlist.Count -1;
                    player.Track = _playlist[nCurrentIndex];
                    break;
                // 다음 트랙으로 이동한다.
                case UserAction.SkipNext:
                    nCurrentIndex++;
                    if (nCurrentIndex >= _playlist.Count)
                        nCurrentIndex = 0;
                    player.Track = _playlist[nCurrentIndex];
                    break;
            }

            NotifyComplete();
        }

        /// <summary>
        /// Called whenever there is an error with playback, such as an AudioTrack not downloading correctly
        /// </summary>
        /// <param name="player">The BackgroundAudioPlayer</param>
        /// <param name="track">The track that had the error</param>
        /// <param name="error">The error that occured</param>
        /// <param name="isFatal">If true, playback cannot continue and playback of the track will stop</param>
        /// <remarks>
        /// This method is not guaranteed to be called in all cases. For example, if the background agent 
        /// itself has an unhandled exception, it won't get called back to handle its own errors.
        /// </remarks>
        protected override void OnError(BackgroundAudioPlayer player, AudioTrack track, Exception error, bool isFatal)
        {
            //TODO: Add code to handle error conditions

            NotifyComplete();
        }

        /// <summary>
        /// Called when the agent request is getting cancelled
        /// </summary>
        protected override void OnCancel()
        {
            NotifyComplete();
        }
    }
}
