
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '1s', target: 1000 },
    { duration: '9s', target: 3500 },
  ]
};

export default function () {
  const res = http.get('http://127.0.0.1:3300/tttt', { headers: { 'Content-Type': 'application/json' } });
  check(res, { 'status was 200': (r) => r.status == 204 });
}