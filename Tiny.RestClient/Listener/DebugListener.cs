﻿#define DEBUG
// We define debug symbol to be able to log in debug even if we are compiled in release mode
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace Tiny.RestClient
{
    /// <summary>
    /// A listener which will trace all requests with <see cref="Debug.WriteLine(object)"/>
    /// </summary>
    public class DebugListener : IListener
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="DebugListener"/> class.
        /// </summary>
        /// <param name="measureTime">true if measure time</param>
        public DebugListener(bool measureTime)
        {
            MeasureTime = measureTime;
        }

        /// <inheritdoc/>
        public bool MeasureTime { get; }

        /// <inheritdoc/>
        public void OnFailedToReceiveResponse(Uri uri, HttpMethod httpMethod, Exception exception, TimeSpan? elapsedTime)
        {
            Debug.WriteLine($"FailedToGetResponse Method = {httpMethod}, Uri = {exception}, ElapsedTime = {ToReadableString(elapsedTime)}");
        }

        /// <inheritdoc/>
        public void OnReceivedResponse(Uri uri, HttpMethod httpMethod, HttpResponseMessage response, TimeSpan? elapsedTime)
        {
            Debug.WriteLine($"Received Method = {httpMethod}, Uri = {uri}, StatusCode = {response.StatusCode}, ElapsedTime = {ToReadableString(elapsedTime)}");
        }

        /// <inheritdoc/>
        public void OnSendingRequest(Uri uri, HttpMethod httpMethod, HttpRequestMessage httpRequestMessage)
        {
            Debug.WriteLine($"Sending Method = {httpMethod}, Uri = {uri}");
        }

        private string ToReadableString(TimeSpan? spanNullable)
        {
            if (spanNullable == null)
            {
                return "-";
            }

            // TODO : redo this code
            var span = spanNullable.Value;

            bool addComa = false;
            var stringBuilder = new StringBuilder(200);
            AddItem(ref addComa, span.Days, "day", stringBuilder);
            AddItem(ref addComa, span.Hours, "hour", stringBuilder);
            AddItem(ref addComa, span.Minutes, "minute", stringBuilder);
            AddItem(ref addComa, span.Seconds, "second", stringBuilder);
            AddItem(ref addComa, span.Milliseconds, "millisecond", stringBuilder);

            return stringBuilder.ToString();
        }

        private void AddItem(ref bool addComa, int value, string text, StringBuilder stringBuilder)
        {
            if (value > 0)
            {
                if (addComa)
                {
                    stringBuilder.AppendFormat(", ");
                }

                stringBuilder.AppendFormat("{0:0} {2}{1}", value, value == 1 ? string.Empty : "s", text);
                addComa = true;
            }
        }
    }
}
