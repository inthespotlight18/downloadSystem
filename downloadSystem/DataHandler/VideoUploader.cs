using downloadSystem.Models;
using downloadSystem;


namespace downloadSystem.DataHandler
{
    public class VideoUploader
    {
        public void UploadVideoToDatabase(AppDbContext context, Recording videoObj)
        {
            try
            {   
                    context.RecordingSet.Add(videoObj);
                    context.SaveChanges();

                    Console.WriteLine("Video uploaded to the DataBase successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading video: {ex.Message}");
            }
        }


        public void PlayVideoFromDatabase(int recordingId)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    // Retrieve the recording from the database
                    var videoRecording = context.RecordingSet.Find(recordingId);

                    if (videoRecording != null)
                    {
                        // Create a file to save the video
                        string videoPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"downloaded_video_{videoRecording.RecordingId}.mp4");

                        // Save the video content to the file
                        File.WriteAllBytes(videoPath, videoRecording.VideoData);

                        Console.WriteLine($"Video saved to: {videoPath}");
                        Console.WriteLine("Now you can play the video using your preferred video player.");
                    }
                    else
                    {
                        Console.WriteLine("Recording not found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing video: {ex.Message}");
            }
        }

    }
}
