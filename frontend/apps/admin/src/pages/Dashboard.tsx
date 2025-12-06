import React from 'react';

const recommendations = [
  'Add descriptive tags like "pastel" and "eco-friendly" to your listings.',
  'Enable custom request templates for faster commissions.',
  'Share a process video to boost trust and conversions.'
];

const Dashboard: React.FC = () => {
  return (
    <div style={{ padding: '24px' }}>
      <h1>Seller Dashboard</h1>
      <div className="am-listings" style={{ gridTemplateColumns: 'repeat(auto-fit, minmax(240px, 1fr))' }}>
        <div className="am-card">
          <h3>Orders</h3>
          <p>32 open / 4 delayed</p>
        </div>
        <div className="am-card">
          <h3>Messages</h3>
          <p>5 awaiting reply</p>
        </div>
        <div className="am-card">
          <h3>Recommendations</h3>
          <ul>
            {recommendations.map((rec) => (
              <li key={rec}>{rec}</li>
            ))}
          </ul>
        </div>
      </div>
      <section style={{ marginTop: '24px' }}>
        <h2>Custom orders</h2>
        <div className="am-card">
          <p>Use AI assisted prompts to craft titles and attributes that convert.</p>
          <button className="am-cta">Generate suggestions</button>
        </div>
      </section>
    </div>
  );
};

export default Dashboard;
