using System;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Graphics.Drawables;

namespace Movielist
{
    class MovieAdapter : BaseAdapter
    {
        List<MovieClass> listMovies;
        Activity activity;

        public MovieAdapter(Activity activity, List<MovieClass> list)
        {
            this.activity = activity;
            this.listMovies = list;

        }

        public override int Count
        {
            get { return listMovies.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            // could wrap a Contact in a Java.Lang.Object
            // to return it here if needed
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(
                Resource.Layout.row_layout, parent, false);
            var movieName = view.FindViewById<TextView>(Resource.Id.movie_title_txt);
            var movieType = view.FindViewById<TextView>(Resource.Id.movie_type_txt);
            movieName.Text = listMovies[position].movie_title;
            movieType.Text = listMovies[position].movie_type;


            return view;
        }
    }
}