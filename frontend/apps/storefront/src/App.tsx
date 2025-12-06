import React, { useEffect, useState } from 'react';
import { Header, SeasonalCarousel, InterestGrid, EditorialList } from '@myamigurumi/ui';
import { fetchListings, Listing } from '@myamigurumi/api';

const seasonalDrops = [
  { title: 'Winter Wonderland', description: 'Fuzzy penguins, snow foxes, and cozy scarves.', expiresAt: new Date(Date.now() + 86400000).toISOString(), image: '/media/winter.jpg' },
  { title: 'Spring Bloom', description: 'Pastel bunnies, sakura bears, and picnic pals.', expiresAt: new Date(Date.now() + 172800000).toISOString(), image: '/media/spring.jpg' }
];

const interests = [
  { title: 'Animals', image: '/media/animals.jpg', blurb: 'Foxes, bunnies, dinos, and jungle friends.' },
  { title: 'Super heroes', image: '/media/heroes.jpg', blurb: 'Custom capes and masks with your palette.' },
  { title: 'Film characters', image: '/media/films.jpg', blurb: 'Indie animations, classics, and cult icons.' }
];

const editorials = [
  { title: 'How to brief a custom commission', category: 'Tutorial', href: '/blog/custom-brief' },
  { title: 'Studio tours: Cozy Stitches', category: 'Community', href: '/blog/cozy-stitches' },
  { title: 'Choosing eco yarns for plushies', category: 'Sustainability', href: '/blog/eco-yarns' }
];

function App() {
  const [listings, setListings] = useState<Listing[]>([]);

  useEffect(() => {
    fetchListings({ customizable: true }).then(setListings).catch(() => setListings([]));
  }, []);

  return (
    <div>
      <Header />
      <main>
        <SeasonalCarousel items={seasonalDrops} />
        <section className="am-grid">
          <h2>Made for you</h2>
          <div className="am-listings">
            {listings.map((listing) => (
              <article key={listing.id} className="am-card">
                <img src={listing.mediaUrls[0] ?? '/media/placeholder.jpg'} alt={listing.title} />
                <div>
                  <p className="am-pill">{listing.category}</p>
                  <h3>{listing.title}</h3>
                  <p>{listing.description}</p>
                  <p className="am-price">${listing.price.toFixed(2)}</p>
                  <button className="am-cta">Personalize this</button>
                </div>
              </article>
            ))}
          </div>
        </section>
        <InterestGrid interests={interests} />
        <EditorialList items={editorials} />
      </main>
      <footer>
        <div>
          <h4>About</h4>
          <a href="/about">Company</a>
          <a href="/policies">Purchase policies</a>
          <a href="/impact">Sustainability</a>
        </div>
        <div>
          <h4>Help</h4>
          <a href="/help">Help center</a>
          <a href="/community">Community</a>
        </div>
        <div>
          <h4>Social</h4>
          <a href="https://instagram.com">Instagram</a>
          <a href="https://youtube.com">YouTube</a>
        </div>
      </footer>
    </div>
  );
}

export default App;
