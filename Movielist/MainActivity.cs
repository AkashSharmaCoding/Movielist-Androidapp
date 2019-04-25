using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Movielist
{
    [Activity(Label = "Movielist", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText movie_name, movie_type;
        Button add_movie_button;
        ListView movie_list;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            movie_name = FindViewById<EditText>(Resource.Id.movie_name);
            movie_type = FindViewById<EditText>(Resource.Id.movie_type);

            add_movie_button = FindViewById<Button>(Resource.Id.add_movie_button);


            movie_list = FindViewById<ListView>(Resource.Id.movie_list);
            List<MovieClass> listMovies = new List<MovieClass>();

            add_movie_button.Click += delegate {

                if (movie_name.Text != "")
                {
                    if (movie_type.Text != "")
                    {

                        MovieClass m1 = new MovieClass();
                        m1.movie_title = movie_name.Text;
                        m1.movie_type = movie_type.Text;
                        listMovies.Add(m1);
                        var listAdapter = new MovieAdapter(this, listMovies);
                        movie_list.Adapter = listAdapter;

                        movie_name.Text = "";
                        movie_type.Text = "";
                    }
                    else
                    {
                        movie_type.RequestFocus();
                        movie_type.SetError("required movie type", null);//,Android.Graphics.Drawables.Drawable);
                    }
                }
                else
                {
                    movie_name.RequestFocus();
                    movie_name.SetError("required movie name", null);
                }

            };
        }
    }
}

