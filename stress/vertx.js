
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '1s', target: 200 },
    { duration: '9s', target: 700 },
  ]
};

export default function () {
  const res = http.post('http://127.0.0.1:3500/products', JSON.stringify({
    "name": "eze",
    "price": 12345
  }), { headers: { 'Content-Type': 'application/json' } });
  check(res, { 'status was 204': (r) => r.status == 204 });
  sleep(1);
}