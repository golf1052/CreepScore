using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CreepScoreAPI
{

    /// <summary>
    /// Realm class
    /// </summary>
    public class RealmStatic
    {
        /// <summary>
        /// The base CDN url
        /// </summary>
        public string cdn;

        /// <summary>
        /// The latest changed version of Dragon Magic's css file
        /// </summary>
        public string css;

        /// <summary>
        /// The latest changed version of Dragon Magic
        /// </summary>
        public string dd;

        /// <summary>
        /// The default language for this realm
        /// </summary>
        public string l;

        /// <summary>
        /// Legacy script mode for IE6 or older
        /// </summary>
        public string lg;

        /// <summary>
        /// The latest changed version for each data type listed
        /// </summary>
        public Dictionary<string, string> n;

        /// <summary>
        /// Special behavior number identifying the largest profileicon id that can be used under 500
        /// </summary>
        public int profileIconMax;

        /// <summary>
        /// Additional api data drawn from other sources that may be related to data dragon functionality
        /// </summary>
        public string store;

        /// <summary>
        /// Current version of this file for this realm
        /// </summary>
        public string v;

        /// <summary>
        /// Realm constructor
        /// </summary>
        /// <param name="cdn">The base CDN url</param>
        /// <param name="css">The latest changed version of Dragon Magic's css file</param>
        /// <param name="dd">The latest changed version of Dragon Magic</param>
        /// <param name="l">The default language for this realm</param>
        /// <param name="lg">Legacy script mode for IE6 or older</param>
        /// <param name="n">The latest changed version for each data type listed</param>
        /// <param name="profileIconMax">Special behavior number identifying the largest profileicon id that can be used under 500</param>
        /// <param name="store">Additional api data drawn from other sources that may be related to data dragon functionality</param>
        /// <param name="v">Current version of this file for this realm</param>
        public RealmStatic(string cdn,
            string css,
            string dd,
            string l,
            string lg,
            JObject n,
            int profileIconMax,
            string store,
            string v)
        {
            this.cdn = cdn;
            this.css = css;
            this.dd = dd;
            this.l = l;
            this.lg = lg;
            this.n = JsonConvert.DeserializeObject<Dictionary<string, string>>(n.ToString());
            this.profileIconMax = profileIconMax;
            this.store = store;
            this.v = v;
        }
    }
}
